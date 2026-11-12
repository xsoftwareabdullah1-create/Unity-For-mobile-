// Obj Exporter feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class ObjExporterFeature:FeatureModuleBase
{
 public const string FeatureId="obj-exporter";
 public ObjExporterFeature():base(FeatureId,"Obj Exporter",new FeatureSetting("objExporterLimit","Obj Exporter budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("objExporterLimit",out var v)?(int)v:128;set=>TrySet("objExporterLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}