// Shared validated feature contract used by root-level engine modules.
namespace ClearGameEngine.RootFeatures;
public sealed record FeatureSetting(string Key,string Label,double DefaultValue,double Minimum,double Maximum);
public abstract class FeatureModuleBase
{
 private readonly Dictionary<string,double> _values=new(StringComparer.Ordinal);
 public string Id{get;} public string DisplayName{get;} public IReadOnlyList<FeatureSetting> Settings{get;} public bool Enabled{get;private set;}=true;
 protected FeatureModuleBase(string id,string name,params FeatureSetting[] settings){Id=id;DisplayName=name;Settings=settings;foreach(var s in settings)_values[s.Key]=s.DefaultValue;}
 public bool SetEnabled(bool value){Enabled=value;return Enabled;}
 public bool TrySet(string key,double value){var s=Settings.FirstOrDefault(x=>x.Key==key);if(s is null||double.IsNaN(value)||double.IsInfinity(value)||value<s.Minimum||value>s.Maximum)return false;_values[key]=value;return true;}
 public bool TryGet(string key,out double value)=>_values.TryGetValue(key,out value);
 public IReadOnlyDictionary<string,double> Snapshot()=>new Dictionary<string,double>(_values,StringComparer.Ordinal);
 public bool Validate(out string error){foreach(var s in Settings)if(!_values.TryGetValue(s.Key,out var v)||double.IsNaN(v)||v<s.Minimum||v>s.Maximum){error="Invalid setting: "+s.Label;return false;}error=string.Empty;return true;}
}