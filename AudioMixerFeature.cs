// Audio Mixer feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class AudioMixerFeature:FeatureModuleBase
{
 public const string FeatureId="audio-mixer";
 public AudioMixerFeature():base(FeatureId,"Audio Mixer",new FeatureSetting("audioMixerLimit","Audio Mixer budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("audioMixerLimit",out var v)?(int)v:128;set=>TrySet("audioMixerLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}