// Scene Serializer feature module. Provides validated, serializable settings to the editor/runtime.
namespace ClearGameEngine.RootFeatures;
public sealed class SceneSerializerFeature:FeatureModuleBase
{
 public const string FeatureId="scene-serializer";
 public SceneSerializerFeature():base(FeatureId,"Scene Serializer",
  new FeatureSetting("sceneSerializerLimit","Scene Serializer budget",128,1,100000),
  new FeatureSetting("quality","Quality level",2,0,4))
 { }
 public int Budget { get=>TryGet("sceneSerializerLimit",out var v)?(int)v:128; set=>TrySet("sceneSerializerLimit",value); }
 public int Quality { get=>TryGet("quality",out var v)?(int)v:2; set=>TrySet("quality",value); }
 public bool IsConfigured=>Validate(out _);
}