// CSharp Runtime feature module. Provides validated, serializable settings to the editor/runtime.
namespace ClearGameEngine.RootFeatures;
public sealed class CSharpRuntimeFeature:FeatureModuleBase
{
 public const string FeatureId="csharp-runtime";
 public CSharpRuntimeFeature():base(FeatureId,"CSharp Runtime",new FeatureSetting("budget","CSharp Runtime budget",512,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("budget",out var v)?(int)v:256;set=>TrySet("budget",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}
