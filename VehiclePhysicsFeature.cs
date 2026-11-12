// Vehicle Physics feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class VehiclePhysicsFeature:FeatureModuleBase
{
 public const string FeatureId="vehicle-physics";
 public VehiclePhysicsFeature():base(FeatureId,"Vehicle Physics",new FeatureSetting("vehiclePhysicsLimit","Vehicle Physics budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("vehiclePhysicsLimit",out var v)?(int)v:128;set=>TrySet("vehiclePhysicsLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}