namespace ForgeMobile.Engine.Scene;

public sealed class CameraComponent
{
    public float FieldOfView { get; set; } = 60;
    public float NearClip { get; set; } = .1f;
    public float FarClip { get; set; } = 1000;
    public bool Orthographic { get; set; }
    public float OrthographicSize { get; set; } = 5;
    public Matrix4x4 Projection(float aspect) => Orthographic ? Matrix4x4.CreateOrthographic(OrthographicSize * aspect, OrthographicSize, NearClip, FarClip) : Matrix4x4.CreatePerspectiveFieldOfView(FieldOfView * MathF.PI / 180, Math.Max(.01f, aspect), NearClip, FarClip);
}
