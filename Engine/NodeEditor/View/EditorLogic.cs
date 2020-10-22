using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Subjects;
using System.Text;
using Altseed2.NodeEditor.ViewModel;

namespace Altseed2.NodeEditor.View
{
    internal sealed class EditorLogic : IDisposable
    {
        private EditorPropertyAccessor propertyAccessor;
        private NodeTreeWindow nodeTreeWindow;
        private SelectedNodeWindow selectedNodeWindow;
        private PreviewWindow previewWindow_refactor;
        private TextureBrowserWindow textureBrowserWindow_refactor;
        private FontBrowserWindow fontBrowserWindow_refactor;

        private object selected;
        private float menuHeight = 20;   // UpdateMainWindow, UpdateNodeTreeWindow, UpdateSelectedWindow, UpdateMenu で使われる
        private bool first;
        
        /// <summary>
        /// 選択されたオブジェクト
        /// </summary>
        public object Selected
        {
            get => selected;
            set
            {
                if (value == selected)
                    return;
                selected = value;

                propertyAccessor.OnSelectedValueChanged();
            }
        }

        /// <summary>
        /// テクスチャ一覧
        /// </summary>
        public List<TextureBase> TextureOptions => textureBrowserWindow_refactor.TextureOptions;

        /// <summary>
        /// フォント一覧
        /// </summary>
        public List<Font> Fonts => fontBrowserWindow_refactor.Fonts;

        /// <summary>
        /// マウス座標
        /// </summary>
        public Vector2F MousePosition => previewWindow_refactor.MousePosition;

        /// <summary>
        /// 
        /// </summary>
        public bool IsMainWindowFocus => previewWindow_refactor.IsMainWindowFocus;

        public TextureBaseToolElement TextureBrowserTarget { get; set; }
        public FontToolElement FontBrowserTarget { get; set; }

        public void InitializeComponents()
        {
            first = true;

            propertyAccessor = new EditorPropertyAccessor(this);
            nodeTreeWindow = new NodeTreeWindow(propertyAccessor, new NodeTreeViewModel(propertyAccessor));
            selectedNodeWindow = new SelectedNodeWindow(propertyAccessor);
            previewWindow_refactor = new PreviewWindow(propertyAccessor);
            textureBrowserWindow_refactor = new TextureBrowserWindow(propertyAccessor);
            fontBrowserWindow_refactor = new FontBrowserWindow(propertyAccessor);
        }

        public void UpdateUi()
        {
            if (first)
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

            first = false;
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
            previewWindow_refactor.Render();
            UpdateMenu();
            nodeTreeWindow.Render();
            selectedNodeWindow.Render();

            if (TextureBrowserTarget != null)
                textureBrowserWindow_refactor.Render();

            if (FontBrowserTarget != null)
                fontBrowserWindow_refactor.UpdateFontBrowser();
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
            menuHeight = Engine.Tool.GetFrameHeight();
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

            public float MenuHeight => _owner.menuHeight;

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
            selectedNodeWindow.Dispose();
        }
    }
}
