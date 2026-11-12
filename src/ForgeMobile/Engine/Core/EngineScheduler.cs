namespace ForgeMobile.Engine.Core;

public sealed class EngineScheduler
{
    private readonly List<(double Due, Action Action)> _tasks = new();
    private double _time;
    public void Schedule(double delay, Action action) => _tasks.Add((_time + Math.Max(0, delay), action));
    public void Tick(double delta) { _time += Math.Max(0, delta); foreach (var task in _tasks.Where(t => t.Due <= _time).ToArray()) { task.Action(); _tasks.Remove(task); } }
}
