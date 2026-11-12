namespace ForgeMobile.Engine.Scripting;

public sealed class ScriptContext
{
    public Dictionary<string,float> Numbers { get; } = new();
    public List<string> Output { get; } = new();
    public Vector3 Position { get; set; }
    public float Get(string key)=>Numbers.TryGetValue(key,out var value)?value:0;
    public void Set(string key,float value)=>Numbers[key]=value;
    public void Log(string text)=>Output.Add(text);
}
