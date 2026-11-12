namespace ForgeMobile.Engine.Assets;

public sealed class AssetRecord
{
    public string Id { get; set; } = Guid.NewGuid().ToString("N");
    public string Path { get; set; } = "";
    public string Name => System.IO.Path.GetFileName(Path);
    public string Kind { get; set; } = "Unknown";
    public long SizeBytes { get; set; }
    public DateTime ModifiedUtc { get; set; }

}
