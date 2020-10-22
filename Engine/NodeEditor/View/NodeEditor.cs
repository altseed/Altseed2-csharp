using System;
using System.Collections.Generic;
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

        private readonly TextureBrowserViewModel _textureBrowserViewModel;
        private readonly FontBrowserViewModel _fontBrowserViewModel;
        private readonly Subject<Unit> _onSelectedNodeChanged = new Subject<Unit>();

        private bool _first;
        private object _selected;

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

#region 委譲
        public List<TextureBase> TextureOptions => _textureBrowserViewModel.Options;

        public List<Font> Fonts => _fontBrowserViewModel.Options;

        public Vector2F MousePosition => _previewWindow.MousePosition;

        public bool IsMainWindowFocus => _previewWindow.IsMainWindowFocus;

        public TextureBaseToolElement TextureBrowserTarget
        {
            get => _textureBrowserViewModel.Selected;
            set => _textureBrowserViewModel.Selected = value;
        }
        public FontToolElement FontBrowserTarget { get; set; }
#endregion

        public NodeEditor()
        {
            _first = true;

            _textureBrowserViewModel = new TextureBrowserViewModel();
            _fontBrowserViewModel = new FontBrowserViewModel();

            IEditorPropertyAccessor propertyAccessor = this;
            _nodeTreeWindow = new NodeTreeWindow(propertyAccessor, new NodeTreeViewModel(propertyAccessor));
            _selectedNodeWindow = new SelectedNodeWindow(propertyAccessor);
            _previewWindow = new PreviewWindow(propertyAccessor);
            _textureBrowserWindow = new TextureBrowserWindow(_textureBrowserViewModel);
            _fontBrowserWindow = new FontBrowserWindow(_fontBrowserViewModel);
        }

        public void UpdateUi()
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
            if (Engine.Tool.Begin("Texture Browser", ToolWindowFlags.None))
            {
                Engine.Tool.End();
            }

            if (Engine.Tool.Begin("Font Browser", ToolWindowFlags.None))
            {
                Engine.Tool.End();
            }

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
            _previewWindow.Render();
            UpdateMenu();
            _nodeTreeWindow.Render();
            _selectedNodeWindow.Render();

            if (TextureBrowserTarget != null)
                _textureBrowserWindow.Render();

            if (FontBrowserTarget != null)
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
