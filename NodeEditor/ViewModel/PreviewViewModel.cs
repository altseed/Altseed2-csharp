namespace Altseed2.NodeEditor.ViewModel
{
    internal sealed class PreviewViewModel
    {
        public bool IsMainWindowFocus { get; set; }
        public Vector2F MousePosition { get; set; }
        public RenderTexture Main { get; set; }

        public void UpdateRenderTexture(bool condition, RenderTexture renderTexture)
        {
            if (condition)
            {
                Main = renderTexture;
            }

            Engine._DefaultCamera.TargetTexture = Main;
        }
    }
}
