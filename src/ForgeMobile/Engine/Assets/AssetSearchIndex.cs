namespace ForgeMobile.Engine.Assets;

public sealed class AssetSearchIndex
{
    private readonly Dictionary<string,string> _documents=new();
    public void Index(string id,string text)=>_documents[id]=text;
    public IEnumerable<string> Query(string text)=>_documents.Where(x=>x.Value.Contains(text,StringComparison.OrdinalIgnoreCase)).Select(x=>x.Key);
    public void Remove(string id)=>_documents.Remove(id);
}
