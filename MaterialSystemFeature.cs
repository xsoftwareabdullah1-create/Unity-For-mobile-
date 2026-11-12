// Material System feature module. Provides validated, serializable settings to the editor/runtime.
namespace ClearGameEngine.RootFeatures;
public sealed class MaterialSystemFeature:FeatureModuleBase
{
 public const string FeatureId="material-system";
 public MaterialSystemFeature():base(FeatureId,"Material System",
  new FeatureSetting("materialSystemLimit","Material System budget",128,1,100000),
  new FeatureSetting("quality","Quality level",2,0,4))
 { }
 public int Budget { get=>TryGet("materialSystemLimit",out var v)?(int)v:128; set=>TrySet("materialSystemLimit",value); }
 public int Quality { get=>TryGet("quality",out var v)?(int)v:2; set=>TrySet("quality",value); }
 public bool IsConfigured=>Validate(out _);
}