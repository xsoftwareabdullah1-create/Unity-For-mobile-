// Collider Shapes feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class ColliderShapesFeature:FeatureModuleBase
{
 public const string FeatureId="collider-shapes";
 public ColliderShapesFeature():base(FeatureId,"Collider Shapes",new FeatureSetting("colliderShapesLimit","Collider Shapes budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("colliderShapesLimit",out var v)?(int)v:128;set=>TrySet("colliderShapesLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}