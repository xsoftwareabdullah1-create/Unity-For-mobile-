// CSharp Bridge feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class CSharpBridgeFeature:FeatureModuleBase
{
 public const string FeatureId="c-sharp-bridge";
 public CSharpBridgeFeature():base(FeatureId,"CSharp Bridge",new FeatureSetting("cSharpBridgeLimit","CSharp Bridge budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("cSharpBridgeLimit",out var v)?(int)v:128;set=>TrySet("cSharpBridgeLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}