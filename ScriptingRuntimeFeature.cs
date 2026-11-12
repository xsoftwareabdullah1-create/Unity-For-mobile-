// Scripting Runtime feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class ScriptingRuntimeFeature:FeatureModuleBase
{
 public const string FeatureId="scripting-runtime";
 public ScriptingRuntimeFeature():base(FeatureId,"Scripting Runtime",new FeatureSetting("scriptingRuntimeLimit","Scripting Runtime budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("scriptingRuntimeLimit",out var v)?(int)v:128;set=>TrySet("scriptingRuntimeLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}