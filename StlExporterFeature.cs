// Stl Exporter feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class StlExporterFeature:FeatureModuleBase
{
 public const string FeatureId="stl-exporter";
 public StlExporterFeature():base(FeatureId,"Stl Exporter",new FeatureSetting("stlExporterLimit","Stl Exporter budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("stlExporterLimit",out var v)?(int)v:128;set=>TrySet("stlExporterLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}