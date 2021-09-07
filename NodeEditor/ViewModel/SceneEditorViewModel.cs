namespace Altseed2.NodeEditor.ViewModel
{
    internal sealed class SceneEditorViewModel
    {
        public bool IsMainWindowFocus { get; set; }
        public Vector2F MousePosition { get; set; }
        public RenderTexture Main { get; set; }

        public RenderedCamera Camera { get; set; }

        public void UpdateRenderTexture(bool condition, RenderTexture renderTexture)
        {
            if (condition)
            {
                Main = renderTexture;
            }

            Camera.TargetTexture = Main;
        }
    }
}
