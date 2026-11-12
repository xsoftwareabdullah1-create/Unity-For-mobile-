// Visual Scripting feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class VisualScriptingFeature:FeatureModuleBase
{
 public const string FeatureId="visual-scripting";
 public VisualScriptingFeature():base(FeatureId,"Visual Scripting",new FeatureSetting("visualScriptingLimit","Visual Scripting budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("visualScriptingLimit",out var v)?(int)v:128;set=>TrySet("visualScriptingLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}