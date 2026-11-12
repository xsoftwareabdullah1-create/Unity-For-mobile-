// Audio Mixer feature module. Provides validated, serializable settings to the editor/runtime.
namespace ClearGameEngine.RootFeatures;
public sealed class AudioMixerFeature:FeatureModuleBase
{
 public const string FeatureId="audio-mixer";
 public AudioMixerFeature():base(FeatureId,"Audio Mixer",new FeatureSetting("budget","Audio Mixer budget",272,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("budget",out var v)?(int)v:128;set=>TrySet("budget",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}
