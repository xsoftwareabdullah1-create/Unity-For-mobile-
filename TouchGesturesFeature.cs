// Touch Gestures feature module. Provides validated, serializable settings to the editor/runtime.
namespace ClearGameEngine.RootFeatures;
public sealed class TouchGesturesFeature:FeatureModuleBase
{
 public const string FeatureId="touch-gestures";
 public TouchGesturesFeature():base(FeatureId,"Touch Gestures",new FeatureSetting("budget","Touch Gestures budget",224,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("budget",out var v)?(int)v:128;set=>TrySet("budget",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}
