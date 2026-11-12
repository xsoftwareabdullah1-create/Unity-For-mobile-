// Gamepad feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class GamepadFeature:FeatureModuleBase
{
 public const string FeatureId="gamepad";
 public GamepadFeature():base(FeatureId,"Gamepad",new FeatureSetting("gamepadLimit","Gamepad budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("gamepadLimit",out var v)?(int)v:128;set=>TrySet("gamepadLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}