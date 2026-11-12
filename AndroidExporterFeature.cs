// Android Exporter feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class AndroidExporterFeature:FeatureModuleBase
{
 public const string FeatureId="android-exporter";
 public AndroidExporterFeature():base(FeatureId,"Android Exporter",new FeatureSetting("androidExporterLimit","Android Exporter budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("androidExporterLimit",out var v)?(int)v:128;set=>TrySet("androidExporterLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}