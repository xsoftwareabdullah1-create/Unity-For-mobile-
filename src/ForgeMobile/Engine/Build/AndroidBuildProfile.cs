namespace ForgeMobile.Engine.Build;

public sealed class AndroidBuildProfile
{
    public string ApplicationId { get; set; } = "com.example.mygame";
    public string VersionName { get; set; } = "1.0.0";
    public int VersionCode { get; set; } = 1;
    public string MinimumApi { get; set; } = "23";
    public string Abi { get; set; } = "arm64-v8a";
    public bool SplitPerAbi { get; set; }

}
