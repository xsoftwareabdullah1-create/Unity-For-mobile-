// Grid System feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class GridSystemFeature:FeatureModuleBase
{
 public const string FeatureId="grid-system";
 public GridSystemFeature():base(FeatureId,"Grid System",new FeatureSetting("gridSystemLimit","Grid System budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("gridSystemLimit",out var v)?(int)v:128;set=>TrySet("gridSystemLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}