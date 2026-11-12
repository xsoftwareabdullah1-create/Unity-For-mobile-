// Physics World feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class PhysicsWorldFeature:FeatureModuleBase
{
 public const string FeatureId="physics-world";
 public PhysicsWorldFeature():base(FeatureId,"Physics World",new FeatureSetting("physicsWorldLimit","Physics World budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("physicsWorldLimit",out var v)?(int)v:128;set=>TrySet("physicsWorldLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}