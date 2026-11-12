// Cpp Native Bridge feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class CppNativeBridgeFeature:FeatureModuleBase
{
 public const string FeatureId="cpp-native-bridge";
 public CppNativeBridgeFeature():base(FeatureId,"Cpp Native Bridge",new FeatureSetting("cppNativeBridgeLimit","Cpp Native Bridge budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("cppNativeBridgeLimit",out var v)?(int)v:128;set=>TrySet("cppNativeBridgeLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}