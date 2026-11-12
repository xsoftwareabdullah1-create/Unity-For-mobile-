namespace ForgeMobile.Engine.Core;

public sealed class EngineEventBus
{
    private readonly Dictionary<Type, List<Delegate>> _handlers = new();
    public void Subscribe<T>(Action<T> handler) { if (!_handlers.TryGetValue(typeof(T), out var list)) _handlers[typeof(T)] = list = new(); list.Add(handler); }
    public void Publish<T>(T value) { if (_handlers.TryGetValue(typeof(T), out var list)) foreach (var handler in list.ToArray()) ((Action<T>)handler)(value); }
    public void Clear() => _handlers.Clear();
}
