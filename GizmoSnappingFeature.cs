// Gizmo Snapping feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class GizmoSnappingFeature:FeatureModuleBase
{
 public const string FeatureId="gizmo-snapping";
 public GizmoSnappingFeature():base(FeatureId,"Gizmo Snapping",new FeatureSetting("gizmoSnappingLimit","Gizmo Snapping budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("gizmoSnappingLimit",out var v)?(int)v:128;set=>TrySet("gizmoSnappingLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}