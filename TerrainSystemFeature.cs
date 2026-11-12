// Terrain System feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class TerrainSystemFeature:FeatureModuleBase
{
 public const string FeatureId="terrain-system";
 public TerrainSystemFeature():base(FeatureId,"Terrain System",new FeatureSetting("terrainSystemLimit","Terrain System budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("terrainSystemLimit",out var v)?(int)v:128;set=>TrySet("terrainSystemLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}