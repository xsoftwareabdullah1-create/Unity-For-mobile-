// Spatial Audio feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class SpatialAudioFeature:FeatureModuleBase
{
 public const string FeatureId="spatial-audio";
 public SpatialAudioFeature():base(FeatureId,"Spatial Audio",new FeatureSetting("spatialAudioLimit","Spatial Audio budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("spatialAudioLimit",out var v)?(int)v:128;set=>TrySet("spatialAudioLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}