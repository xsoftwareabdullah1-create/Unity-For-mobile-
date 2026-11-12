namespace ForgeMobile.Engine.Scene;

public sealed class MeshRendererSettings
{
    public string MaterialId { get; set; } = "builtin:default";
    public bool CastShadows { get; set; } = true;
    public bool ReceiveShadows { get; set; } = true;
    public bool Visible { get; set; } = true;

}
