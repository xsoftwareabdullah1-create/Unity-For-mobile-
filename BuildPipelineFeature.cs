// Build Pipeline feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class BuildPipelineFeature:FeatureModuleBase
{
 public const string FeatureId="build-pipeline";
 public BuildPipelineFeature():base(FeatureId,"Build Pipeline",new FeatureSetting("buildPipelineLimit","Build Pipeline budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("buildPipelineLimit",out var v)?(int)v:128;set=>TrySet("buildPipelineLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}