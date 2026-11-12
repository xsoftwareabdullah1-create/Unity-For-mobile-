namespace ForgeMobile.Engine.Core;

public sealed class EngineVersion
{
    public const string Product = "Forge Mobile";
    public const string Version = "0.2.0";
    public const int SceneSchema = 2;
    public static string Full => $"{Product} {Version}";
}
