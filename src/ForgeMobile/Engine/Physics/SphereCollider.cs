namespace ForgeMobile.Engine.Physics;

public sealed class SphereCollider : Collider
{
    public float Radius { get; set; } = .5f;
    public override SceneBounds Bounds => new(){Min=Center-new Vector3(Radius),Max=Center+new Vector3(Radius)};

}
