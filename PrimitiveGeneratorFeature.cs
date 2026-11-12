// Primitive Generator feature module. Provides validated, serializable settings to the editor/runtime.
namespace ClearGameEngine.RootFeatures;
public sealed class PrimitiveGeneratorFeature:FeatureModuleBase
{
 public const string FeatureId="primitive-generator";
 public PrimitiveGeneratorFeature():base(FeatureId,"Primitive Generator",
  new FeatureSetting("primitiveGeneratorLimit","Primitive Generator budget",128,1,100000),
  new FeatureSetting("quality","Quality level",2,0,4))
 { }
 public int Budget { get=>TryGet("primitiveGeneratorLimit",out var v)?(int)v:128; set=>TrySet("primitiveGeneratorLimit",value); }
 public int Quality { get=>TryGet("quality",out var v)?(int)v:2; set=>TrySet("quality",value); }
 public bool IsConfigured=>Validate(out _);
}