// Touch Controls feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class TouchControlsFeature:FeatureModuleBase
{
 public const string FeatureId="touch-controls";
 public TouchControlsFeature():base(FeatureId,"Touch Controls",new FeatureSetting("touchControlsLimit","Touch Controls budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("touchControlsLimit",out var v)?(int)v:128;set=>TrySet("touchControlsLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}