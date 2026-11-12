// Windows Exporter feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class WindowsExporterFeature:FeatureModuleBase
{
 public const string FeatureId="windows-exporter";
 public WindowsExporterFeature():base(FeatureId,"Windows Exporter",new FeatureSetting("windowsExporterLimit","Windows Exporter budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("windowsExporterLimit",out var v)?(int)v:128;set=>TrySet("windowsExporterLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}