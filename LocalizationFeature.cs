// Localization feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class LocalizationFeature:FeatureModuleBase
{
 public const string FeatureId="localization";
 public LocalizationFeature():base(FeatureId,"Localization",new FeatureSetting("localizationLimit","Localization budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("localizationLimit",out var v)?(int)v:128;set=>TrySet("localizationLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}