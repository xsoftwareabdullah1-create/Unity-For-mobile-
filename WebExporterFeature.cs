// Web Exporter feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class WebExporterFeature:FeatureModuleBase
{
 public const string FeatureId="web-exporter";
 public WebExporterFeature():base(FeatureId,"Web Exporter",new FeatureSetting("webExporterLimit","Web Exporter budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("webExporterLimit",out var v)?(int)v:128;set=>TrySet("webExporterLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}