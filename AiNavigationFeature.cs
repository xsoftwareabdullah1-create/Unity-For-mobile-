// Ai Navigation feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class AiNavigationFeature:FeatureModuleBase
{
 public const string FeatureId="ai-navigation";
 public AiNavigationFeature():base(FeatureId,"Ai Navigation",new FeatureSetting("aiNavigationLimit","Ai Navigation budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("aiNavigationLimit",out var v)?(int)v:128;set=>TrySet("aiNavigationLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}