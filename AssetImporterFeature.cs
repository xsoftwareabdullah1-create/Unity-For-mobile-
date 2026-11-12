// Asset Importer feature module. Provides validated, serializable settings to the editor/runtime.
namespace ClearGameEngine.RootFeatures;
public sealed class AssetImporterFeature:FeatureModuleBase
{
 public const string FeatureId="asset-importer";
 public AssetImporterFeature():base(FeatureId,"Asset Importer",
  new FeatureSetting("assetImporterLimit","Asset Importer budget",128,1,100000),
  new FeatureSetting("quality","Quality level",2,0,4))
 { }
 public int Budget { get=>TryGet("assetImporterLimit",out var v)?(int)v:128; set=>TrySet("assetImporterLimit",value); }
 public int Quality { get=>TryGet("quality",out var v)?(int)v:2; set=>TrySet("quality",value); }
 public bool IsConfigured=>Validate(out _);
}