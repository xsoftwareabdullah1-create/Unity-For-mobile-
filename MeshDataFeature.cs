// Mesh Data feature module. Provides validated, serializable settings to the editor/runtime.
namespace ClearGameEngine.RootFeatures;
public sealed class MeshDataFeature:FeatureModuleBase
{
 public const string FeatureId="mesh-data";
 public MeshDataFeature():base(FeatureId,"Mesh Data",
  new FeatureSetting("meshDataLimit","Mesh Data budget",128,1,100000),
  new FeatureSetting("quality","Quality level",2,0,4))
 { }
 public int Budget { get=>TryGet("meshDataLimit",out var v)?(int)v:128; set=>TrySet("meshDataLimit",value); }
 public int Quality { get=>TryGet("quality",out var v)?(int)v:2; set=>TrySet("quality",value); }
 public bool IsConfigured=>Validate(out _);
}