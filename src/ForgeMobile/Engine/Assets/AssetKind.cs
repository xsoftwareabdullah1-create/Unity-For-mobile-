namespace ForgeMobile.Engine.Assets;

public sealed class AssetKind
{

    public const string Scene="Scene", Script="Script", Model="Model", Texture="Texture", Audio="Audio", Material="Material", Folder="Folder", Unknown="Unknown";
    public static string FromExtension(string path)=>System.IO.Path.GetExtension(path).ToLowerInvariant() switch {".scene"=>Scene,".cs"=>Script,".obj" or ".gltf" or ".glb"=>Model,".png" or ".jpg" or ".jpeg"=>Texture,".wav" or ".ogg" or ".mp3"=>Audio,".mat"=>Material,_=>Unknown};
}
