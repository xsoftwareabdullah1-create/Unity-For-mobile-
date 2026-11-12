// Networking feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class NetworkingFeature:FeatureModuleBase
{
 public const string FeatureId="networking";
 public NetworkingFeature():base(FeatureId,"Networking",new FeatureSetting("networkingLimit","Networking budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("networkingLimit",out var v)?(int)v:128;set=>TrySet("networkingLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}