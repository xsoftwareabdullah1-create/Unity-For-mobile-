namespace ForgeMobile.Engine.Assets;

public sealed class AssetId
{
    public string Value { get; }
    public AssetId(string value)=>Value=string.IsNullOrWhiteSpace(value)?throw new ArgumentException("Asset ID required"):value;
    public override string ToString()=>Value;

}
