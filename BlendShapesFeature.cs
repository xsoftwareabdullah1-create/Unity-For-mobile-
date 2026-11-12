// Blend Shapes feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class BlendShapesFeature:FeatureModuleBase
{
 public const string FeatureId="blend-shapes";
 public BlendShapesFeature():base(FeatureId,"Blend Shapes",new FeatureSetting("blendShapesLimit","Blend Shapes budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("blendShapesLimit",out var v)?(int)v:128;set=>TrySet("blendShapesLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}