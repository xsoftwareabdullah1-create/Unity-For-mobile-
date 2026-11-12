namespace ForgeMobile.Engine.Physics;

public sealed class PhysicsSettings
{
    public Vector3 Gravity { get; set; } = new(0,-9.81f,0);
    public int SolverIterations { get; set; } = 8;
    public float FixedDelta { get; set; } = 1f/60f;
    public bool Enabled { get; set; } = true;

}
