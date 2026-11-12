namespace ForgeMobile.Engine.Physics;

public sealed class RigidBody
{
    public Vector3 Position { get; set; }
    public Vector3 Velocity { get; set; }
    public Vector3 Force { get; set; }
    public float Mass { get; set; } = 1;
    public bool IsKinematic { get; set; }
    public float LinearDamping { get; set; } = .02f;
    public void AddForce(Vector3 force)=>Force+=force;
    public void Integrate(Vector3 gravity,float dt) { if(IsKinematic)return; var mass=Math.Max(.0001f,Mass); Velocity+=(gravity+Force/mass)*dt; Velocity*=Math.Clamp(1-LinearDamping*dt,0,1); Position+=Velocity*dt; Force=Vector3.Zero; }
}
