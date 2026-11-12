// Water System feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class WaterSystemFeature:FeatureModuleBase
{
 public const string FeatureId="water-system";
 public WaterSystemFeature():base(FeatureId,"Water System",new FeatureSetting("waterSystemLimit","Water System budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("waterSystemLimit",out var v)?(int)v:128;set=>TrySet("waterSystemLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}