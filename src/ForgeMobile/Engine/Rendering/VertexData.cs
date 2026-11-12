namespace ForgeMobile.Engine.Rendering;

public sealed class VertexData
{
    public Vector3 Position { get; set; }
    public Vector3 Normal { get; set; } = Vector3.UnitY;
    public Vector2 Uv { get; set; }
    public Vector4 Color { get; set; } = Vector4.One;

}
