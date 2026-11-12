// Addressables feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class AddressablesFeature:FeatureModuleBase
{
 public const string FeatureId="addressables";
 public AddressablesFeature():base(FeatureId,"Addressables",new FeatureSetting("addressablesLimit","Addressables budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("addressablesLimit",out var v)?(int)v:128;set=>TrySet("addressablesLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}