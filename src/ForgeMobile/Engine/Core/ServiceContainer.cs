namespace ForgeMobile.Engine.Core;

public sealed class ServiceContainer
{
    private readonly Dictionary<Type, object> _services = new();
    public void Register<T>(T service) where T : notnull => _services[typeof(T)] = service;
    public T Get<T>() where T : notnull => _services.TryGetValue(typeof(T), out var value) ? (T)value : throw new InvalidOperationException($"Service {typeof(T).Name} not registered");
    public bool TryGet<T>(out T? value) { if (_services.TryGetValue(typeof(T), out var item)) { value = (T)item; return true; } value = default; return false; }
}
