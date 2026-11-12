namespace ForgeMobile.Engine.Core;

public sealed class FrameStatistics
{
    private readonly Queue<double> _samples = new();
    public double AverageFps => _samples.Count == 0 ? 0 : 1d / (_samples.Average());
    public double FrameMs => _samples.Count == 0 ? 0 : _samples.Average() * 1000;
    public void Add(double delta) { if (delta <= 0 || !double.IsFinite(delta)) return; _samples.Enqueue(delta); while (_samples.Count > 120) _samples.Dequeue(); }
}
