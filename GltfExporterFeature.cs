// Gltf Exporter feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class GltfExporterFeature:FeatureModuleBase
{
 public const string FeatureId="gltf-exporter";
 public GltfExporterFeature():base(FeatureId,"Gltf Exporter",new FeatureSetting("gltfExporterLimit","Gltf Exporter budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("gltfExporterLimit",out var v)?(int)v:128;set=>TrySet("gltfExporterLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}