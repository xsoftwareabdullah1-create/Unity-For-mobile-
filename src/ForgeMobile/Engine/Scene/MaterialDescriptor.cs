namespace ForgeMobile.Engine.Scene;

public sealed class MaterialDescriptor
{
    public string Name { get; set; } = "New Material";
    public Vector4 BaseColor { get; set; } = Vector4.One;
    public float Metallic { get; set; }
    public float Roughness { get; set; } = .7f;
    public string Shader { get; set; } = "Standard";
    public void Clamp() { Metallic = Math.Clamp(Metallic, 0, 1); Roughness = Math.Clamp(Roughness, .02f, 1); }
}
