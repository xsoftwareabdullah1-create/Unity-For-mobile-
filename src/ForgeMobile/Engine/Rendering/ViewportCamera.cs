namespace ForgeMobile.Engine.Rendering;

public sealed class ViewportCamera
{
    public Vector3 Position { get; set; } = new(4,3,6);
    public Vector3 Target { get; set; }
    public float FieldOfView { get; set; } = 55;
    public float Near { get; set; } = .1f;
    public float Far { get; set; } = 500;
    public Matrix4x4 View => Matrix4x4.CreateLookAt(Position, Target, Vector3.UnitY);
    public Matrix4x4 Projection(float aspect) => Matrix4x4.CreatePerspectiveFieldOfView(FieldOfView * MathF.PI / 180, Math.Max(aspect,.01f), Near, Far);
}
