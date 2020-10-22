using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Subjects;
using Altseed2.NodeEditor.ViewModel;

namespace Altseed2.NodeEditor.View
{
    internal sealed class EditorLogic : IDisposable
    {
        private readonly EditorPropertyAccessor _propertyAccessor;
        private readonly NodeTreeWindow _nodeTreeWindow;
        private readonly SelectedNodeWindow _selectedNodeWindow;
        private readonly PreviewWindow _previewWindowRefactor;
        private readonly TextureBrowserWindow _textureBrowserWindowRefactor;
        private readonly FontBrowserWindow _fontBrowserWindowRefactor;

        private bool _first;
        private object _selected;
        private float _menuHeight = 20;
        
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

                _propertyAccessor.OnSelectedValueChanged();
            }
        }

        /// <summary>
        /// テクスチャ一覧
        /// </summary>
        public List<TextureBase> TextureOptions => _textureBrowserWindowRefactor.TextureOptions;

        /// <summary>
        /// フォント一覧
        /// </summary>
        public List<Font> Fonts => _fontBrowserWindowRefactor.Fonts;

        /// <summary>
        /// マウス座標
        /// </summary>
        public Vector2F MousePosition => _previewWindowRefactor.MousePosition;

        /// <summary>
        /// 
        /// </summary>
        public bool IsMainWindowFocus => _previewWindowRefactor.IsMainWindowFocus;

        public TextureBaseToolElement TextureBrowserTarget { get; set; }
        public FontToolElement FontBrowserTarget { get; set; }

        public EditorLogic()
        {
            _first = true;
            _propertyAccessor = new EditorPropertyAccessor(this);
            _nodeTreeWindow = new NodeTreeWindow(_propertyAccessor, new NodeTreeViewModel(_propertyAccessor));
            _selectedNodeWindow = new SelectedNodeWindow(_propertyAccessor);
            _previewWindowRefactor = new PreviewWindow(_propertyAccessor);
            _textureBrowserWindowRefactor = new TextureBrowserWindow(_propertyAccessor);
            _fontBrowserWindowRefactor = new FontBrowserWindow(_propertyAccessor);
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

        private void UpdateCameraGroup()
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
                }
            }
        }

        private void UpdateComponents()
        {
            _previewWindowRefactor.Render();
            UpdateMenu();
            _nodeTreeWindow.Render();
            _selectedNodeWindow.Render();

            if (TextureBrowserTarget != null)
                _textureBrowserWindowRefactor.Render();

            if (FontBrowserTarget != null)
                _fontBrowserWindowRefactor.UpdateFontBrowser();
        }

        void UpdateMenu()
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
            _menuHeight = Engine.Tool.GetFrameHeight();
        }
        
        private sealed class EditorPropertyAccessor : IEditorPropertyAccessor
        {
            private readonly EditorLogic _owner;
            private readonly Subject<Unit> _onSelectedNodeChanged = new Subject<Unit>();

            public EditorPropertyAccessor(EditorLogic owner)
            {
                _owner = owner;
            }

            public object Selected
            {
                get => _owner.Selected;
                set => _owner.Selected = value;
            }

            public float MenuHeight => _owner._menuHeight;

            public IObservable<Unit> OnPropertyChanged_Selected_refactor => _onSelectedNodeChanged;
            public TextureBaseToolElement TextureBrowserTarget
            {
                get => _owner.TextureBrowserTarget;
                set => _owner.TextureBrowserTarget = value;
            }

            public FontToolElement FontBrowserTarget
            {
                get => _owner.FontBrowserTarget;
                set => _owner.FontBrowserTarget = value;
            }

            public void OnSelectedValueChanged() => _onSelectedNodeChanged.OnNext(Unit.Default);
        }

        public void Dispose()
        {
            _selectedNodeWindow.Dispose();
        }
    }
}
