// Audio Engine feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class AudioEngineFeature:FeatureModuleBase
{
 public const string FeatureId="audio-engine";
 public AudioEngineFeature():base(FeatureId,"Audio Engine",new FeatureSetting("audioEngineLimit","Audio Engine budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("audioEngineLimit",out var v)?(int)v:128;set=>TrySet("audioEngineLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}