// Model Importer feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class ModelImporterFeature:FeatureModuleBase
{
 public const string FeatureId="model-importer";
 public ModelImporterFeature():base(FeatureId,"Model Importer",new FeatureSetting("modelImporterLimit","Model Importer budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("modelImporterLimit",out var v)?(int)v:128;set=>TrySet("modelImporterLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}