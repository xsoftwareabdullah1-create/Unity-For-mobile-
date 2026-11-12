// Object Selection feature module. Provides validated, serializable settings to the editor/runtime.
namespace ClearGameEngine.RootFeatures;
public sealed class ObjectSelectionFeature:FeatureModuleBase
{
 public const string FeatureId="object-selection";
 public ObjectSelectionFeature():base(FeatureId,"Object Selection",
  new FeatureSetting("objectSelectionLimit","Object Selection budget",128,1,100000),
  new FeatureSetting("quality","Quality level",2,0,4))
 { }
 public int Budget { get=>TryGet("objectSelectionLimit",out var v)?(int)v:128; set=>TrySet("objectSelectionLimit",value); }
 public int Quality { get=>TryGet("quality",out var v)?(int)v:2; set=>TrySet("quality",value); }
 public bool IsConfigured=>Validate(out _);
}