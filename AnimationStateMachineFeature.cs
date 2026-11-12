// Animation State Machine feature module. Provides validated, serializable settings to the editor/runtime.
namespace ClearGameEngine.RootFeatures;
public sealed class AnimationStateMachineFeature:FeatureModuleBase
{
 public const string FeatureId="animation-state-machine";
 public AnimationStateMachineFeature():base(FeatureId,"Animation State Machine",new FeatureSetting("budget","Animation State Machine budget",432,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("budget",out var v)?(int)v:256;set=>TrySet("budget",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}
