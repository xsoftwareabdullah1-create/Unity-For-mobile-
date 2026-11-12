namespace ForgeMobile.Engine.Core;

public sealed class MainThreadQueue
{
    private readonly Queue<Action> _queue = new();
    private readonly object _sync = new();
    public void Post(Action action) { lock (_sync) _queue.Enqueue(action); }
    public int Drain(int limit = 256) { var count = 0; while (count < limit) { Action? action; lock (_sync) { if (_queue.Count == 0) break; action = _queue.Dequeue(); } action(); count++; } return count; }
}
