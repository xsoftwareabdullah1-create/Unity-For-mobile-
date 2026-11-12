// Scene Graph feature module. Provides validated, serializable settings to the editor/runtime.
namespace ClearGameEngine.RootFeatures;
public sealed class SceneGraphFeature:FeatureModuleBase
{
 public const string FeatureId="scene-graph";
 public SceneGraphFeature():base(FeatureId,"Scene Graph",
  new FeatureSetting("sceneGraphLimit","Scene Graph budget",128,1,100000),
  new FeatureSetting("quality","Quality level",2,0,4))
 { }
 public int Budget { get=>TryGet("sceneGraphLimit",out var v)?(int)v:128; set=>TrySet("sceneGraphLimit",value); }
 public int Quality { get=>TryGet("quality",out var v)?(int)v:2; set=>TrySet("quality",value); }
 public bool IsConfigured=>Validate(out _);
}