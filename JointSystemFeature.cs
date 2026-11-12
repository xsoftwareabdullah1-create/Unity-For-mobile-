// Joint System feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class JointSystemFeature:FeatureModuleBase
{
 public const string FeatureId="joint-system";
 public JointSystemFeature():base(FeatureId,"Joint System",new FeatureSetting("jointSystemLimit","Joint System budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("jointSystemLimit",out var v)?(int)v:128;set=>TrySet("jointSystemLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}