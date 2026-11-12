// Asset Dependency feature module. Provides validated, serializable settings to the editor/runtime.
namespace ClearGameEngine.RootFeatures;
public sealed class AssetDependencyFeature:FeatureModuleBase
{
 public const string FeatureId="asset-dependency";
 public AssetDependencyFeature():base(FeatureId,"Asset Dependency",
  new FeatureSetting("assetDependencyLimit","Asset Dependency budget",128,1,100000),
  new FeatureSetting("quality","Quality level",2,0,4))
 { }
 public int Budget { get=>TryGet("assetDependencyLimit",out var v)?(int)v:128; set=>TrySet("assetDependencyLimit",value); }
 public int Quality { get=>TryGet("quality",out var v)?(int)v:2; set=>TrySet("quality",value); }
 public bool IsConfigured=>Validate(out _);
}