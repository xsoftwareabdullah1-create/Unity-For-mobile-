// Lod System feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class LodSystemFeature:FeatureModuleBase
{
 public const string FeatureId="lod-system";
 public LodSystemFeature():base(FeatureId,"Lod System",new FeatureSetting("lodSystemLimit","Lod System budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("lodSystemLimit",out var v)?(int)v:128;set=>TrySet("lodSystemLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}