// Play Mode feature module. Provides validated, serializable settings to the editor/runtime.
namespace ClearGameEngine.RootFeatures;
public sealed class PlayModeFeature:FeatureModuleBase
{
 public const string FeatureId="play-mode";
 public PlayModeFeature():base(FeatureId,"Play Mode",new FeatureSetting("budget","Play Mode budget",768,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("budget",out var v)?(int)v:384;set=>TrySet("budget",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}
