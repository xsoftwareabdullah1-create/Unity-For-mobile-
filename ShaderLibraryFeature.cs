// Shader Library feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class ShaderLibraryFeature:FeatureModuleBase
{
 public const string FeatureId="shader-library";
 public ShaderLibraryFeature():base(FeatureId,"Shader Library",new FeatureSetting("shaderLibraryLimit","Shader Library budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("shaderLibraryLimit",out var v)?(int)v:128;set=>TrySet("shaderLibraryLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}