namespace ForgeMobile.Engine.Physics;

public sealed class Collider
{
    public string EntityId { get; set; } = "";
    public Vector3 Center { get; set; }
    public bool IsTrigger { get; set; }
    public abstract SceneBounds Bounds { get; }

}
