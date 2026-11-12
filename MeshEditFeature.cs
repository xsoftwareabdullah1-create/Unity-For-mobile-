// Mesh Edit feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class MeshEditFeature:FeatureModuleBase
{
 public const string FeatureId="mesh-edit";
 public MeshEditFeature():base(FeatureId,"Mesh Edit",new FeatureSetting("meshEditLimit","Mesh Edit budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("meshEditLimit",out var v)?(int)v:128;set=>TrySet("meshEditLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}