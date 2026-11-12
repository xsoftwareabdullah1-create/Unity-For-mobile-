namespace ForgeMobile.Engine.Assets;

public sealed class AssetDatabase
{
    private readonly Dictionary<string,AssetRecord> _assets=new(StringComparer.OrdinalIgnoreCase);
    public IReadOnlyCollection<AssetRecord> All=>_assets.Values;
    public void Upsert(AssetRecord record)=>_assets[record.Path]=record;
    public bool Remove(string path)=>_assets.Remove(path);
    public AssetRecord? Find(string path)=>_assets.GetValueOrDefault(path);
    public IEnumerable<AssetRecord> Search(string query)=>_assets.Values.Where(x=>x.Name.Contains(query,StringComparison.OrdinalIgnoreCase));
}
