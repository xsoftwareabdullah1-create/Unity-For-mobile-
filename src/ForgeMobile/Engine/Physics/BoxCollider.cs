namespace ForgeMobile.Engine.Physics;

public sealed class BoxCollider
{
    public Vector3 Size { get; set; } = Vector3.One;
    public override SceneBounds Bounds => new(){Min=Center-Size*.5f,Max=Center+Size*.5f};

}
