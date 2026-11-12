namespace ForgeMobile.Engine.Assets;

public sealed class AssetPath
{

    public static string Normalize(string path)=>path.Replace('\\\\','/').TrimStart('/');
    public static bool IsInsideProject(string path)=>!Normalize(path).Split('/').Any(x=>x=="..");
}
