// Render Queue feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class RenderQueueFeature:FeatureModuleBase
{
 public const string FeatureId="render-queue";
 public RenderQueueFeature():base(FeatureId,"Render Queue",new FeatureSetting("renderQueueLimit","Render Queue budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("renderQueueLimit",out var v)?(int)v:128;set=>TrySet("renderQueueLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}