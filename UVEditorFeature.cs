// UVEditor feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class UVEditorFeature:FeatureModuleBase
{
 public const string FeatureId="u-v-editor";
 public UVEditorFeature():base(FeatureId,"UVEditor",new FeatureSetting("uVEditorLimit","UVEditor budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("uVEditorLimit",out var v)?(int)v:128;set=>TrySet("uVEditorLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}