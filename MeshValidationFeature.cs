// Mesh Validation feature module. Provides validated, serializable settings to the editor/runtime.
namespace ClearGameEngine.RootFeatures;
public sealed class MeshValidationFeature:FeatureModuleBase
{
 public const string FeatureId="mesh-validation";
 public MeshValidationFeature():base(FeatureId,"Mesh Validation",
  new FeatureSetting("meshValidationLimit","Mesh Validation budget",128,1,100000),
  new FeatureSetting("quality","Quality level",2,0,4))
 { }
 public int Budget { get=>TryGet("meshValidationLimit",out var v)?(int)v:128; set=>TrySet("meshValidationLimit",value); }
 public int Quality { get=>TryGet("quality",out var v)?(int)v:2; set=>TrySet("quality",value); }
 public bool IsConfigured=>Validate(out _);
}