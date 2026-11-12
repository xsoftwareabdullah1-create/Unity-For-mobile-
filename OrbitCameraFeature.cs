// Orbit Camera feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class OrbitCameraFeature:FeatureModuleBase
{
 public const string FeatureId="orbit-camera";
 public OrbitCameraFeature():base(FeatureId,"Orbit Camera",new FeatureSetting("orbitCameraLimit","Orbit Camera budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("orbitCameraLimit",out var v)?(int)v:128;set=>TrySet("orbitCameraLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}