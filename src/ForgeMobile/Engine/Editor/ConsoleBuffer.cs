namespace ForgeMobile.Engine.Editor;

public sealed class ConsoleBuffer
{
    private readonly List<ConsoleMessage> _messages=new();
    public IReadOnlyList<ConsoleMessage> Messages=>_messages;
    public void Write(string level,string text,string source="Editor"){_messages.Add(new(){Level=level,Text=text,Source=source});if(_messages.Count>5000)_messages.RemoveAt(0);}
    public void Clear()=>_messages.Clear();
}
