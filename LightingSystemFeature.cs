// Lighting System feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class LightingSystemFeature:FeatureModuleBase
{
 public const string FeatureId="lighting-system";
 public LightingSystemFeature():base(FeatureId,"Lighting System",new FeatureSetting("lightingSystemLimit","Lighting System budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("lightingSystemLimit",out var v)?(int)v:128;set=>TrySet("lightingSystemLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}