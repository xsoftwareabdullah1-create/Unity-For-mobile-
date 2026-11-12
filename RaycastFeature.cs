// Raycast feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class RaycastFeature:FeatureModuleBase
{
 public const string FeatureId="raycast";
 public RaycastFeature():base(FeatureId,"Raycast",new FeatureSetting("raycastLimit","Raycast budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("raycastLimit",out var v)?(int)v:128;set=>TrySet("raycastLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}