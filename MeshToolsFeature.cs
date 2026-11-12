// Mesh Tools feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class MeshToolsFeature:FeatureModuleBase
{
 public const string FeatureId="mesh-tools";
 public MeshToolsFeature():base(FeatureId,"Mesh Tools",new FeatureSetting("meshToolsLimit","Mesh Tools budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("meshToolsLimit",out var v)?(int)v:128;set=>TrySet("meshToolsLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}