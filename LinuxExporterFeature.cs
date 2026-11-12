// Linux Exporter feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class LinuxExporterFeature:FeatureModuleBase
{
 public const string FeatureId="linux-exporter";
 public LinuxExporterFeature():base(FeatureId,"Linux Exporter",new FeatureSetting("linuxExporterLimit","Linux Exporter budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("linuxExporterLimit",out var v)?(int)v:128;set=>TrySet("linuxExporterLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}