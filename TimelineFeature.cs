// Timeline feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class TimelineFeature:FeatureModuleBase
{
 public const string FeatureId="timeline";
 public TimelineFeature():base(FeatureId,"Timeline",new FeatureSetting("timelineLimit","Timeline budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("timelineLimit",out var v)?(int)v:128;set=>TrySet("timelineLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}