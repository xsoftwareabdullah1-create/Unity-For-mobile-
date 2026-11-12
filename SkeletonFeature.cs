// Skeleton feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class SkeletonFeature:FeatureModuleBase
{
 public const string FeatureId="skeleton";
 public SkeletonFeature():base(FeatureId,"Skeleton",new FeatureSetting("skeletonLimit","Skeleton budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("skeletonLimit",out var v)?(int)v:128;set=>TrySet("skeletonLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}