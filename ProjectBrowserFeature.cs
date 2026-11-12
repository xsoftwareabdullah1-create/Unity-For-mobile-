// Project Browser feature module. Provides validated, serializable settings to the editor/runtime.
namespace ClearGameEngine.RootFeatures;
public sealed class ProjectBrowserFeature:FeatureModuleBase
{
 public const string FeatureId="project-browser";
 public ProjectBrowserFeature():base(FeatureId,"Project Browser",
  new FeatureSetting("projectBrowserLimit","Project Browser budget",128,1,100000),
  new FeatureSetting("quality","Quality level",2,0,4))
 { }
 public int Budget { get=>TryGet("projectBrowserLimit",out var v)?(int)v:128; set=>TrySet("projectBrowserLimit",value); }
 public int Quality { get=>TryGet("quality",out var v)?(int)v:2; set=>TrySet("quality",value); }
 public bool IsConfigured=>Validate(out _);
}