namespace ForgeMobile.Engine.Scripting;

public sealed class ScriptProgram
{
    public List<ScriptInstruction> Instructions { get; } = new();
    public List<ScriptDiagnostic> Diagnostics { get; } = new();
    public bool IsValid => Diagnostics.Count==0;

}
