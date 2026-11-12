namespace ForgeMobile.Engine.Rendering;

public sealed class OrbitController
{
    public float Distance { get; private set; } = 8;
    public float Yaw { get; private set; } = .7f;
    public float Pitch { get; private set; } = .35f;
    public void Orbit(float dx,float dy) { Yaw += dx * .008f; Pitch = Math.Clamp(Pitch + dy * .008f, -.05f, 1.5f); }
    public void Zoom(float amount) => Distance = Math.Clamp(Distance * MathF.Exp(amount * .01f), .5f, 250);
    public Vector3 Position(Vector3 target) { var cp = MathF.Cos(Pitch); return target + new Vector3(MathF.Sin(Yaw)*cp,MathF.Sin(Pitch),MathF.Cos(Yaw)*cp)*Distance; }
}
