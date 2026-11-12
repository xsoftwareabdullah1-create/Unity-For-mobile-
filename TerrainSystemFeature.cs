// Terrain System feature module. Provides validated, serializable settings to the editor/runtime.
namespace ClearGameEngine.RootFeatures;
public sealed class TerrainSystemFeature:FeatureModuleBase
{
 public const string FeatureId="terrain-system";
 public TerrainSystemFeature():base(FeatureId,"Terrain System",new FeatureSetting("budget","Terrain System budget",480,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("budget",out var v)?(int)v:256;set=>TrySet("budget",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}
