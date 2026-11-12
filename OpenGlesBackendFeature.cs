// Open Gles Backend feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class OpenGlesBackendFeature:FeatureModuleBase
{
 public const string FeatureId="open-gles-backend";
 public OpenGlesBackendFeature():base(FeatureId,"Open Gles Backend",new FeatureSetting("openGlesBackendLimit","Open Gles Backend budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("openGlesBackendLimit",out var v)?(int)v:128;set=>TrySet("openGlesBackendLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}