namespace ForgeMobile.Engine.Scene;

public sealed class ComponentCatalog
{
    private readonly Dictionary<string, Type> _types = new(StringComparer.OrdinalIgnoreCase);
    public void Register<T>(string name) where T : SceneComponent => _types[name] = typeof(T);
    public IReadOnlyDictionary<string, Type> Types => _types;
    public SceneComponent? Create(string name) => _types.TryGetValue(name, out var type) ? (SceneComponent?)Activator.CreateInstance(type) : null;
}
