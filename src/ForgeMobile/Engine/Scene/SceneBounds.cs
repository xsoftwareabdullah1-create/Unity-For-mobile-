namespace ForgeMobile.Engine.Scene;

public sealed class SceneBounds
{
    public Vector3 Min { get; set; }
    public Vector3 Max { get; set; }
    public Vector3 Center => (Min + Max) * .5f;
    public Vector3 Size => Max - Min;
    public bool Contains(Vector3 p) => p.X >= Min.X && p.X <= Max.X && p.Y >= Min.Y && p.Y <= Max.Y && p.Z >= Min.Z && p.Z <= Max.Z;
}
