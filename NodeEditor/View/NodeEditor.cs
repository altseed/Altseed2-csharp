using System;
using System.Linq;
using System.Reactive;
using System.Reactive.Subjects;
using Altseed2.NodeEditor.ViewModel;

namespace Altseed2.NodeEditor.View
{
    internal sealed class NodeEditor : IDisposable, IEditorPropertyAccessor
    {
        private readonly NodeTreeWindow _nodeTreeWindow;
        private readonly SelectedNodeWindow _selectedNodeWindow;
        private readonly PreviewWindow _previewWindow;
        private readonly TextureBrowserWindow _textureBrowserWindow;
        private readonly FontBrowserWindow _fontBrowserWindow;
        private readonly Subject<Unit> _onSelectedNodeChanged = new Subject<Unit>();

        public NodeTreeWindow NodeTreeWindow { get { return _nodeTreeWindow; } }
        public SelectedNodeWindow SelectedNodeWindow { get { return _selectedNodeWindow; } }
        public PreviewWindow PreviewWindow { get { return _previewWindow; } }
        public TextureBrowserWindow TextureBrowserWindow { get { return _textureBrowserWindow; } }
        public FontBrowserWindow FontBrowserWindow { get { return _fontBrowserWindow; }}

        private bool _first;
        private Node _selected;

        public NodeEditor(NodeEditorViewModel viewModel)
        {
            _first = true;

            var t = new ToolElementTreeFactory();
            t.GuiInfoRepository.SetAltseed2DefaultObjectMapping();

            IEditorPropertyAccessor propertyAccessor = this;
            _nodeTreeWindow = new NodeTreeWindow(propertyAccessor, new NodeTreeViewModel(propertyAccessor));
            _selectedNodeWindow = new SelectedNodeWindow(propertyAccessor, t);
            _previewWindow = new PreviewWindow(propertyAccessor, viewModel.PreviewViewModel);
            _textureBrowserWindow = new TextureBrowserWindow(viewModel.TextureBrowserViewModel);
            _fontBrowserWindow = new FontBrowserWindow(viewModel.FontBrowserViewModel);
        }

        /// <summary>
        /// 選択されたオブジェクト
        /// </summary>
        public Node Selected
        {
            get => _selected;
            set
            {
                if (value == _selected)
                    return;
                _selected = value;

                _onSelectedNodeChanged.OnNext(Unit.Default);
            }
        }

        public float MenuHeight { get; private set; } = 20;

        public IObservable<Unit> OnSelectedNodeChanged => _onSelectedNodeChanged;

        public void Render()
        {
            if (_first)
            {
                OnFirstUpdate();
            }

            UpdateCameraGroup();
            UpdateComponents();
            if (Altseed2.Engine.Tool.Begin("History", Altseed2.ToolWindowFlags.NoCollapse))
            {
                for (int i = NodeEditorHost.CommandManager.Commands.Count() - 1; i >= Math.Max(0, NodeEditorHost.CommandManager.Commands.Count() - 20); i--)
                {
                    var info = NodeEditorHost.CommandManager.Commands[i].GetInformation();

                    var text = string.Empty;
                    if (i == NodeEditorHost.CommandManager.CurrentCommandIndex)
                    {
                        text += "-";
                    }
                    text += info.Name;
                    Altseed2.Engine.Tool.Text(text);
                    Altseed2.Engine.Tool.Text(info.Detail);
                }
                Engine.Tool.End();
            }
        }

        public void Dispose()
        {
            _selectedNodeWindow.Dispose();
        }

        private void OnFirstUpdate()
        {
            bool pOpen = true;
            if (Engine.Tool.Begin("Texture Browser", ref pOpen, ToolWindowFlags.None))
            {
            }
            Engine.Tool.End();

            pOpen = false;
            if (Engine.Tool.Begin("Font Browser", ref pOpen, ToolWindowFlags.None))
            {
            }
            Engine.Tool.End();

            _first = false;
        }

        private static void UpdateCameraGroup()
        {
            foreach (var node in Engine.GetNodes().Union(Engine.GetNodes().SelectMany(obj => obj.EnumerateDescendants())))
            {
                try
                {
                    var propertyInfo = node.GetType().GetProperty("CameraGroup");
                    propertyInfo?.SetValue(node, (ulong)propertyInfo.GetValue(node) | 1u << 63);
                }
                catch
                {
                    // TODO: 例外を無条件に握りつぶしたくはない。少なくともどんな例外を握りつぶしたいかを明示したい
                }
            }
        }

        private void UpdateComponents()
        {
            Engine.Tool.SetNextWindowViewport(0);
            Engine.Tool.BeginDockHost("host", new Vector2F(0, MenuHeight));
            Engine.Tool.End();

            UpdateMenu();

            _previewWindow.Render();
            _nodeTreeWindow.Render();
            _selectedNodeWindow.Render();

            if (_textureBrowserWindow.IsActive)
                _textureBrowserWindow.Render();

            if (_fontBrowserWindow.IsActive)
                _fontBrowserWindow.UpdateFontBrowser();

            if(LoadFilePath != "")
            {
                var text = System.IO.File.ReadAllText(LoadFilePath);
                NodeEditorHost.NodeTreeGroup = PartsTreeSystem.NodeTreeGroup.Deserialize(text);
                NodeEditorHost.NodeTree = PartsTreeSystem.Utility.CreateNodeFromNodeTreeGroup(NodeEditorHost.NodeTreeGroup, NodeEditorHost.Environment);
                NodeEditorHost.CommandManager = new PartsTreeSystem.CommandManager();
                LoadFilePath = "";
            }
        }

        private void UpdateMenu()
        {
            if (Engine.Tool.BeginMainMenuBar())
            {
                if (Engine.Tool.BeginMenu("File", true))
                {
                    Engine.Tool.MenuItem("New", "", false, true);
                    Engine.Tool.MenuItem("Open", "", false, true);
                    Engine.Tool.EndMenu();
                }
                if (Engine.Tool.BeginMenu("Edit", true))
                {
                    Engine.Tool.MenuItem("Copy", "", false, true);
                    Engine.Tool.MenuItem("Paste", "", false, true);
                    Engine.Tool.EndMenu();
                }
                if(Engine.Tool.MenuItem("Undo", "", false, true))
                {
                    Undo();
                }
                if(Engine.Tool.MenuItem("Redo", "", false, true))
                {
                    Redo();
                }
                if(Engine.Tool.MenuItem("Save", "", false, true))
                {
                    Save();
                }
                if(Engine.Tool.MenuItem("Load", "", false, true))
                {
                    Load();
                }
                Engine.Tool.Text(Engine.CurrentFPS.ToString());
                Engine.Tool.EndMainMenuBar();
            }
            MenuHeight = Engine.Tool.GetFrameHeight();
        }
        string LoadFilePath = "";

        public void Undo()
        {
            NodeEditorHost.CommandManager.Undo(NodeEditorHost.Environment);
        }

        public void Redo() 
        {
            NodeEditorHost.CommandManager.Redo(NodeEditorHost.Environment);
        }

        public void Save()
        {
            var path = Altseed2.Engine.Tool.SaveDialog("nodes", System.IO.Directory.GetCurrentDirectory());
            Save(path);
        }

        public void Save(string filepath)
        {
            if (!string.IsNullOrEmpty(filepath))
            {
                var text = NodeEditorHost.NodeTreeGroup.Serialize(NodeEditorHost.Environment);
                var ext = System.IO.Path.GetExtension(filepath).ToLower();

                if (ext != ".nodes")
                {
                    filepath += ".nodes";
                }

                System.IO.File.WriteAllText(filepath, text);
            }
            NodeEditorHost.NodeTree = PartsTreeSystem.Utility.CreateNodeFromNodeTreeGroup(NodeEditorHost.NodeTreeGroup, NodeEditorHost.Environment);
        }

        public void Load()
        {
            var path = Altseed2.Engine.Tool.OpenDialog("nodes", System.IO.Directory.GetCurrentDirectory());
            Load(path);
        }

        public void Load(string filepath)
        {
            if (!string.IsNullOrEmpty(filepath))
            {
                LoadFilePath = filepath;
            }
        }
    }
}
