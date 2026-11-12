namespace ForgeMobile.Engine.Assets;

public sealed class AssetThumbnailMetadata
{
    public string AssetId { get; set; } = "";
    public string CacheKey { get; set; } = "";
    public int Width { get; set; } = 128;
    public int Height { get; set; } = 128;
    public string Placeholder { get; set; } = "file";

}
