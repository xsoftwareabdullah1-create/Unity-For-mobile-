// Keyboard Input feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class KeyboardInputFeature:FeatureModuleBase
{
 public const string FeatureId="keyboard-input";
 public KeyboardInputFeature():base(FeatureId,"Keyboard Input",new FeatureSetting("keyboardInputLimit","Keyboard Input budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("keyboardInputLimit",out var v)?(int)v:128;set=>TrySet("keyboardInputLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}