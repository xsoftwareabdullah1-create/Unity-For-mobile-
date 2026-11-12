// Transform feature module. Provides validated, serializable settings to the editor/runtime.
namespace ClearGameEngine.RootFeatures;
public sealed class TransformFeature:FeatureModuleBase
{
 public const string FeatureId="transform";
 public TransformFeature():base(FeatureId,"Transform",
  new FeatureSetting("transformLimit","Transform budget",128,1,100000),
  new FeatureSetting("quality","Quality level",2,0,4))
 { }
 public int Budget { get=>TryGet("transformLimit",out var v)?(int)v:128; set=>TrySet("transformLimit",value); }
 public int Quality { get=>TryGet("quality",out var v)?(int)v:2; set=>TrySet("quality",value); }
 public bool IsConfigured=>Validate(out _);
}