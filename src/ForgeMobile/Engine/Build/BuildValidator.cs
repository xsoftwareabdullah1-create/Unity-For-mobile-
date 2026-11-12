namespace ForgeMobile.Engine.Build;

public sealed class BuildValidator
{

    public static ValidationResult Validate(AndroidBuildProfile p){var r=new ValidationResult();if(!System.Text.RegularExpressions.Regex.IsMatch(p.ApplicationId,@"^[A-Za-z][A-Za-z0-9_]*(\\.[A-Za-z][A-Za-z0-9_]*)+$"))r.Add("Application ID must be a valid reverse-DNS package name");if(p.VersionCode<1)r.Add("Version code must be positive");if(p.Abi!="arm64-v8a"&&p.Abi!="armeabi-v7a")r.Add("Unsupported ABI");return r;}
}
