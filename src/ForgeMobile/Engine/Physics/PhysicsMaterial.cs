namespace ForgeMobile.Engine.Physics;

public sealed class PhysicsMaterial
{
    public float StaticFriction { get; set; } = .6f;
    public float DynamicFriction { get; set; } = .4f;
    public float Bounciness { get; set; }
    public void Clamp() { StaticFriction=Math.Clamp(StaticFriction,0,1); DynamicFriction=Math.Clamp(DynamicFriction,0,1); Bounciness=Math.Clamp(Bounciness,0,1); }

}
