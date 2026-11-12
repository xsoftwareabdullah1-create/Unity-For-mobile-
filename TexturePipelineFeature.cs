// Texture Pipeline feature module. Provides validated, serializable settings to the editor/runtime.
namespace ClearGameEngine.RootFeatures;
public sealed class TexturePipelineFeature:FeatureModuleBase
{
 public const string FeatureId="texture-pipeline";
 public TexturePipelineFeature():base(FeatureId,"Texture Pipeline",
  new FeatureSetting("texturePipelineLimit","Texture Pipeline budget",128,1,100000),
  new FeatureSetting("quality","Quality level",2,0,4))
 { }
 public int Budget { get=>TryGet("texturePipelineLimit",out var v)?(int)v:128; set=>TrySet("texturePipelineLimit",value); }
 public int Quality { get=>TryGet("quality",out var v)?(int)v:2; set=>TrySet("quality",value); }
 public bool IsConfigured=>Validate(out _);
}