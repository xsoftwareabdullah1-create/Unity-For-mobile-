namespace ForgeMobile.Engine.Physics;

public sealed class CollisionPair
{
    public string A { get; set; } = "";
    public string B { get; set; } = "";
    public Vector3 Normal { get; set; }
    public float Penetration { get; set; }

}
