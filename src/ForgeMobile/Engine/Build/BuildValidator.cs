namespace ForgeMobile.Engine.Build;

public sealed class BuildValidator
{
    public static ValidationResult Validate(AndroidBuildProfile profile)
    {
        var result = new ValidationResult();
        if (!System.Text.RegularExpressions.Regex.IsMatch(profile.ApplicationId, @"^[A-Za-z][A-Za-z0-9_]*([.][A-Za-z][A-Za-z0-9_]*)+$"))
            result.Add("Application ID must be a valid reverse-DNS package name");
        if (profile.VersionCode < 1) result.Add("Version code must be positive");
        if (profile.Abi != "arm64-v8a" && profile.Abi != "armeabi-v7a") result.Add("Unsupported ABI");
        return result;
    }
}
