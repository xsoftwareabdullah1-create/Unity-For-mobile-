// Scene Gizmos feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class SceneGizmosFeature:FeatureModuleBase
{
 public const string FeatureId="scene-gizmos";
 public SceneGizmosFeature():base(FeatureId,"Scene Gizmos",new FeatureSetting("sceneGizmosLimit","Scene Gizmos budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("sceneGizmosLimit",out var v)?(int)v:128;set=>TrySet("sceneGizmosLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}