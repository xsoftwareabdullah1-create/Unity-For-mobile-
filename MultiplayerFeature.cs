// Multiplayer feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class MultiplayerFeature:FeatureModuleBase
{
 public const string FeatureId="multiplayer";
 public MultiplayerFeature():base(FeatureId,"Multiplayer",new FeatureSetting("multiplayerLimit","Multiplayer budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("multiplayerLimit",out var v)?(int)v:128;set=>TrySet("multiplayerLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}