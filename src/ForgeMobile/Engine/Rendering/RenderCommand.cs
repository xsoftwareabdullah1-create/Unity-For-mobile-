namespace ForgeMobile.Engine.Rendering;

public sealed class RenderCommand
{
    public string Kind { get; set; } = "DrawMesh";
    public string EntityId { get; set; } = "";
    public string MeshId { get; set; } = "builtin:cube";
    public string MaterialId { get; set; } = "builtin:default";
    public Matrix4x4 World { get; set; } = Matrix4x4.Identity;

}
