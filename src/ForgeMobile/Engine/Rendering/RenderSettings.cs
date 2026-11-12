namespace ForgeMobile.Engine.Rendering;

public sealed class RenderSettings
{
    public Vector4 ClearColor { get; set; } = new(.24f,.28f,.34f,1);
    public bool ShowGrid { get; set; } = true;
    public bool ShowGizmos { get; set; } = true;
    public bool Wireframe { get; set; }
    public int MsaaSamples { get; set; } = 4;

}
