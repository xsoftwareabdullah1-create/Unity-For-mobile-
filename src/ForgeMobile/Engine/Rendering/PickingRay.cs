namespace ForgeMobile.Engine.Rendering;

public sealed class PickingRay
{
    public Vector3 Origin { get; set; }
    public Vector3 Direction { get; set; } = -Vector3.UnitZ;
    public Vector3 At(float distance) => Origin + Vector3.Normalize(Direction) * distance;
}
