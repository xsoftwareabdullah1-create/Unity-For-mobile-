// Picking System feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class PickingSystemFeature:FeatureModuleBase
{
 public const string FeatureId="picking-system";
 public PickingSystemFeature():base(FeatureId,"Picking System",new FeatureSetting("pickingSystemLimit","Picking System budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("pickingSystemLimit",out var v)?(int)v:128;set=>TrySet("pickingSystemLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}