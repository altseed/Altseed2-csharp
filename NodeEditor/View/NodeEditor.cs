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

        private bool _first;
        private object _selected;

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
        public object Selected
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
                Engine.Tool.Text(Engine.CurrentFPS.ToString());
                Engine.Tool.EndMainMenuBar();
            }
            MenuHeight = Engine.Tool.GetFrameHeight();
        }
    }
}
