namespace ForgeMobile.Engine.Assets;

public sealed class AssetDependencyGraph
{
    private readonly Dictionary<string,HashSet<string>> _edges=new();
    public void AddDependency(string asset,string dependency){if(!_edges.TryGetValue(asset,out var set))_edges[asset]=set=new();set.Add(dependency);}
    public IReadOnlyCollection<string> DependenciesOf(string asset)=>_edges.TryGetValue(asset,out var set)?set:Array.Empty<string>();
    public IEnumerable<string> DependentsOf(string dependency)=>_edges.Where(x=>x.Value.Contains(dependency)).Select(x=>x.Key);
}
