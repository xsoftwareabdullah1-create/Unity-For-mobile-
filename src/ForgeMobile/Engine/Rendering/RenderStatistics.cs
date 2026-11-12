namespace ForgeMobile.Engine.Rendering;

public sealed class RenderStatistics
{
    public int DrawCalls { get; set; }
    public int Triangles { get; set; }
    public int VisibleObjects { get; set; }
    public double CpuMilliseconds { get; set; }
    public void Reset() { DrawCalls=0; Triangles=0; VisibleObjects=0; CpuMilliseconds=0; }
}
