namespace ForgeMobile.Engine.Physics;

public sealed class PhysicsWorld
{
    public PhysicsSettings Settings { get; } = new();
    public List<RigidBody> Bodies { get; } = new();
    public void Step(float dt) { if(!Settings.Enabled)return; foreach(var body in Bodies) body.Integrate(Settings.Gravity,Math.Clamp(dt,0,.05f)); }
    public void Add(RigidBody body)=>Bodies.Add(body);
    public void Remove(RigidBody body)=>Bodies.Remove(body);
    public void Clear()=>Bodies.Clear();
}
