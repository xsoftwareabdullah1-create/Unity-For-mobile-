// Scene Streaming feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class SceneStreamingFeature:FeatureModuleBase
{
 public const string FeatureId="scene-streaming";
 public SceneStreamingFeature():base(FeatureId,"Scene Streaming",new FeatureSetting("sceneStreamingLimit","Scene Streaming budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("sceneStreamingLimit",out var v)?(int)v:128;set=>TrySet("sceneStreamingLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}