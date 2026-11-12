namespace ForgeMobile.Engine.Rendering;

public sealed class RenderPassDescriptor
{
    public string Name { get; set; } = "Forward";
    public int Order { get; set; }
    public bool Enabled { get; set; } = true;
    public Vector4 ClearColor { get; set; } = new(0,0,0,1);

}
