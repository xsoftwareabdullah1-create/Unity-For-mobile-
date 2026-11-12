namespace ForgeMobile.Engine.Build;

public sealed class BuildTarget
{

    public const string Android="Android", Windows="Windows", Linux="Linux", Web="Web";
    public static readonly string[] Supported={Android};
    public static bool IsSupported(string target)=>Supported.Contains(target,StringComparer.OrdinalIgnoreCase);
}
