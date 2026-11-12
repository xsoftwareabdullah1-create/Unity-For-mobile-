namespace ForgeMobile.Engine.Scene;

public sealed class LightComponent
{
    public string Kind { get; set; } = "Directional";
    public Vector3 Color { get; set; } = Vector3.One;
    public float Intensity { get; set; } = 1;
    public float Range { get; set; } = 10;
    public bool CastShadows { get; set; } = true;

}
