using System;
using System.Linq;
using System.Reactive;
using System.Reactive.Subjects;
using Altseed2.NodeEditor.ViewModel;
using Altseed2.NodeEditor.Model;

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
            get
            {
                if(_selected == null)
                    return null;

                if (!_selected.IsRegistered)
                {
                    _selected = NodeEditorModel.FindInstance(_selectedNodeInstanceID);
                    _onSelectedNodeChanged.OnNext(Unit.Default);
                }
                    
                return _selected;
            }
            set
            {
                if (value.InstanceID == _selectedNodeInstanceID)
                    return;
                _selected = value;
                _selectedNodeInstanceID = value.InstanceID;
                _onSelectedNodeChanged.OnNext(Unit.Default);
            }
        }
        private int _selectedNodeInstanceID = -1;

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
                NodeEditorModel.Load(LoadFilePath);
            }
        }

        private void UpdateMenu()
        {
            if (Engine.Tool.BeginMainMenuBar())
            {
                if (Engine.Tool.BeginMenu("File", true))
                {
                    if (Engine.Tool.MenuItem("Save", "", false, true))
                    {
                        NodeEditorModel.Save();
                    }
                    if (Engine.Tool.MenuItem("Load", "", false, true))
                    {
                        NodeEditorModel.Load();
                    }
                    Engine.Tool.EndMenu();
                }
                if (Engine.Tool.BeginMenu("Edit", true))
                {
                    if (Engine.Tool.MenuItem("Undo", "", false, true))
                    {
                        NodeEditorModel.Undo();
                    }
                    if (Engine.Tool.MenuItem("Redo", "", false, true))
                    {
                        NodeEditorModel.Redo();
                    }
                    Engine.Tool.EndMenu();
                }
                
                
                Engine.Tool.Text(Engine.CurrentFPS.ToString());
                Engine.Tool.EndMainMenuBar();
            }
            MenuHeight = Engine.Tool.GetFrameHeight();
        }
        string LoadFilePath = "";
    }
}
