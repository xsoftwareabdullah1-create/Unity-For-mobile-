// Undo Redo feature module. Provides validated, serializable settings to the editor/runtime.
namespace ClearGameEngine.RootFeatures;
public sealed class UndoRedoFeature:FeatureModuleBase
{
 public const string FeatureId="undo-redo";
 public UndoRedoFeature():base(FeatureId,"Undo Redo",
  new FeatureSetting("undoRedoLimit","Undo Redo budget",128,1,100000),
  new FeatureSetting("quality","Quality level",2,0,4))
 { }
 public int Budget { get=>TryGet("undoRedoLimit",out var v)?(int)v:128; set=>TrySet("undoRedoLimit",value); }
 public int Quality { get=>TryGet("quality",out var v)?(int)v:2; set=>TrySet("quality",value); }
 public bool IsConfigured=>Validate(out _);
}