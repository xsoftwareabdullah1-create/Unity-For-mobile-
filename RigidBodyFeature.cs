// Rigid Body feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class RigidBodyFeature:FeatureModuleBase
{
 public const string FeatureId="rigid-body";
 public RigidBodyFeature():base(FeatureId,"Rigid Body",new FeatureSetting("rigidBodyLimit","Rigid Body budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("rigidBodyLimit",out var v)?(int)v:128;set=>TrySet("rigidBodyLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}