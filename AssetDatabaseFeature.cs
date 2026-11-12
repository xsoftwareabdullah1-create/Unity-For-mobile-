// Asset Database feature module. Provides validated, serializable settings to the editor/runtime.
namespace ClearGameEngine.RootFeatures;
public sealed class AssetDatabaseFeature:FeatureModuleBase
{
 public const string FeatureId="asset-database";
 public AssetDatabaseFeature():base(FeatureId,"Asset Database",
  new FeatureSetting("assetDatabaseLimit","Asset Database budget",128,1,100000),
  new FeatureSetting("quality","Quality level",2,0,4))
 { }
 public int Budget { get=>TryGet("assetDatabaseLimit",out var v)?(int)v:128; set=>TrySet("assetDatabaseLimit",value); }
 public int Quality { get=>TryGet("quality",out var v)?(int)v:2; set=>TrySet("quality",value); }
 public bool IsConfigured=>Validate(out _);
}