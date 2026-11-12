namespace ForgeMobile.Engine.Scripting;

public sealed class ScriptDiagnostic
{
    public string Message { get; set; } = "";
    public int Line { get; set; }
    public string Severity { get; set; } = "Error";
    public override string ToString()=>$"{Severity}({Line}): {Message}";

}
