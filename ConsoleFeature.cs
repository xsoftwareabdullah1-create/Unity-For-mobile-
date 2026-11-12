// Console feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class ConsoleFeature:FeatureModuleBase
{
 public const string FeatureId="console";
 public ConsoleFeature():base(FeatureId,"Console",new FeatureSetting("consoleLimit","Console budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("consoleLimit",out var v)?(int)v:128;set=>TrySet("consoleLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}