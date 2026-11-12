// Animator feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class AnimatorFeature:FeatureModuleBase
{
 public const string FeatureId="animator";
 public AnimatorFeature():base(FeatureId,"Animator",new FeatureSetting("animatorLimit","Animator budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("animatorLimit",out var v)?(int)v:128;set=>TrySet("animatorLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}