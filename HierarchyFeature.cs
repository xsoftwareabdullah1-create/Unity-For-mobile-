// Hierarchy feature module. Provides validated, serializable settings to the editor/runtime.
namespace ClearGameEngine.RootFeatures;
public sealed class HierarchyFeature:FeatureModuleBase
{
 public const string FeatureId="hierarchy";
 public HierarchyFeature():base(FeatureId,"Hierarchy",
  new FeatureSetting("hierarchyLimit","Hierarchy budget",128,1,100000),
  new FeatureSetting("quality","Quality level",2,0,4))
 { }
 public int Budget { get=>TryGet("hierarchyLimit",out var v)?(int)v:128; set=>TrySet("hierarchyLimit",value); }
 public int Quality { get=>TryGet("quality",out var v)?(int)v:2; set=>TrySet("quality",value); }
 public bool IsConfigured=>Validate(out _);
}