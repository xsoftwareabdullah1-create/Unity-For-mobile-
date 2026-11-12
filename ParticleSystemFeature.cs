// Particle System feature module. Validated, serializable runtime settings.
namespace ClearGameEngine.RootFeatures;
public sealed class ParticleSystemFeature:FeatureModuleBase
{
 public const string FeatureId="particle-system";
 public ParticleSystemFeature():base(FeatureId,"Particle System",new FeatureSetting("particleSystemLimit","Particle System budget",128,1,100000),new FeatureSetting("quality","Quality level",2,0,4)){}
 public int Budget{get=>TryGet("particleSystemLimit",out var v)?(int)v:128;set=>TrySet("particleSystemLimit",value);}
 public int Quality{get=>TryGet("quality",out var v)?(int)v:2;set=>TrySet("quality",value);}
 public bool IsConfigured=>Validate(out _);
}