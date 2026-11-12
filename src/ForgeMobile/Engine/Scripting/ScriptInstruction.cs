namespace ForgeMobile.Engine.Scripting;

public sealed class ScriptInstruction
{
    public string OpCode { get; set; } = "NOP";
    public string Operand { get; set; } = "";
    public float Number { get; set; }

}
