namespace ForgeMobile.Engine.Scene;

public sealed class SceneTransform
{
    public Vector3 Position { get; set; }
    public Vector3 RotationEuler { get; set; }
    public Vector3 Scale { get; set; } = Vector3.One;
    public Matrix4x4 LocalMatrix => Matrix4x4.CreateScale(Scale) * Matrix4x4.CreateFromYawPitchRoll(RotationEuler.Y * MathF.PI / 180, RotationEuler.X * MathF.PI / 180, RotationEuler.Z * MathF.PI / 180) * Matrix4x4.CreateTranslation(Position);
    public Vector3 Forward => Vector3.TransformNormal(-Vector3.UnitZ, Matrix4x4.CreateFromYawPitchRoll(RotationEuler.Y * MathF.PI / 180, RotationEuler.X * MathF.PI / 180, RotationEuler.Z * MathF.PI / 180));
}
