namespace ForgeMobile.Engine.Core;

public sealed class EngineClock
{
    public double DeltaTime { get; private set; }
    public double ElapsedTime { get; private set; }
    public long Frame { get; private set; }
    public void Tick(double delta) { DeltaTime = Math.Clamp(delta, 0, 0.25); ElapsedTime += DeltaTime; Frame++; }
    public void Reset() { DeltaTime = 0; ElapsedTime = 0; Frame = 0; }
}
