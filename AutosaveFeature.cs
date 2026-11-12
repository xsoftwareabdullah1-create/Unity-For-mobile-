// Autosave feature module. Validated runtime configuration.
namespace ClearGameEngine.RootFeatures;
public sealed class AutosaveFeature:FeatureModuleBase{public const string FeatureId="autosave";public AutosaveFeature():base(FeatureId,"Autosave",new FeatureSetting("budget","Autosave budget",736,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){} public int Budget{get=>TryGet("budget",out var v)?(int)v:512;set=>TrySet("budget",value);} public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);} public bool IsConfigured=>Validate(out _);}
