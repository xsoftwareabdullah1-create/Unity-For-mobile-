// Fbx Exporter feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class FbxExporterFeature:FeatureModuleBase
{
 public const string FeatureId="fbx-exporter";
 public FbxExporterFeature():base(FeatureId,"Fbx Exporter",new FeatureSetting("fbxExporterLimit","Fbx Exporter budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("fbxExporterLimit",out var v)?(int)v:128;set=>TrySet("fbxExporterLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}