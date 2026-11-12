// Memory Profiler feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class MemoryProfilerFeature:FeatureModuleBase
{
 public const string FeatureId="memory-profiler";
 public MemoryProfilerFeature():base(FeatureId,"Memory Profiler",new FeatureSetting("memoryProfilerLimit","Memory Profiler budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("memoryProfilerLimit",out var v)?(int)v:128;set=>TrySet("memoryProfilerLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}