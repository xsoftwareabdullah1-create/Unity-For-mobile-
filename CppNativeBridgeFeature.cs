// Cpp Native Bridge feature module. Provides validated, serializable settings to the editor/runtime.
namespace ClearGameEngine.RootFeatures;
public sealed class CppNativeBridgeFeature:FeatureModuleBase
{
 public const string FeatureId="cpp-native-bridge";
 public CppNativeBridgeFeature():base(FeatureId,"Cpp Native Bridge",new FeatureSetting("budget","Cpp Native Bridge budget",560,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("budget",out var v)?(int)v:256;set=>TrySet("budget",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}
