namespace ForgeMobile.Engine.Rendering;

public sealed class ResourceCache
{
    private readonly Dictionary<string,object> _resources = new();
    public void Put<T>(string key,T resource) where T:notnull => _resources[key]=resource;
    public bool TryGet<T>(string key,out T? resource) { if(_resources.TryGetValue(key,out var value) && value is T typed){resource=typed;return true;} resource=default;return false; }
    public void Remove(string key)=>_resources.Remove(key);
    public void Clear()=>_resources.Clear();
}
