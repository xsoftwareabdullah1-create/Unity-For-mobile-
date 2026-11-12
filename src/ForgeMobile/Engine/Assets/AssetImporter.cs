namespace ForgeMobile.Engine.Assets;

public sealed class AssetImporter
{

    public static AssetRecord Describe(string path,FileInfo info)=>new(){Path=AssetPath.Normalize(path),Kind=AssetKind.FromExtension(path),SizeBytes=info.Exists?info.Length:0,ModifiedUtc=info.Exists?info.LastWriteTimeUtc:DateTime.UtcNow};
}
