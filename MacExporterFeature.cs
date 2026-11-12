// Mac Exporter feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class MacExporterFeature:FeatureModuleBase
{
 public const string FeatureId="mac-exporter";
 public MacExporterFeature():base(FeatureId,"Mac Exporter",new FeatureSetting("macExporterLimit","Mac Exporter budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("macExporterLimit",out var v)?(int)v:128;set=>TrySet("macExporterLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}