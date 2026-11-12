// Camera System feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class CameraSystemFeature:FeatureModuleBase
{
 public const string FeatureId="camera-system";
 public CameraSystemFeature():base(FeatureId,"Camera System",new FeatureSetting("cameraSystemLimit","Camera System budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("cameraSystemLimit",out var v)?(int)v:128;set=>TrySet("cameraSystemLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}