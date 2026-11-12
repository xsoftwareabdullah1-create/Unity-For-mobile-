// Entity Component feature module. Provides validated, serializable settings to the editor/runtime.
namespace ClearGameEngine.RootFeatures;
public sealed class EntityComponentFeature:FeatureModuleBase
{
 public const string FeatureId="entity-component";
 public EntityComponentFeature():base(FeatureId,"Entity Component",
  new FeatureSetting("entityComponentLimit","Entity Component budget",128,1,100000),
  new FeatureSetting("quality","Quality level",2,0,4))
 { }
 public int Budget { get=>TryGet("entityComponentLimit",out var v)?(int)v:128; set=>TrySet("entityComponentLimit",value); }
 public int Quality { get=>TryGet("quality",out var v)?(int)v:2; set=>TrySet("quality",value); }
 public bool IsConfigured=>Validate(out _);
}