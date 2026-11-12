// Render Profiler feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class RenderProfilerFeature:FeatureModuleBase
{
 public const string FeatureId="render-profiler";
 public RenderProfilerFeature():base(FeatureId,"Render Profiler",new FeatureSetting("renderProfilerLimit","Render Profiler budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("renderProfilerLimit",out var v)?(int)v:128;set=>TrySet("renderProfilerLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}