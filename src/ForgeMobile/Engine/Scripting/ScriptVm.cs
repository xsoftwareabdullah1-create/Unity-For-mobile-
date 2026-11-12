namespace ForgeMobile.Engine.Scripting;

public sealed class ScriptVm
{

    public static bool Execute(ScriptProgram program,ScriptContext context) { if(!program.IsValid)return false; foreach(var i in program.Instructions){switch(i.OpCode){case "LOG":context.Log(i.Operand);break;case "SET":context.Set(i.Operand,i.Number);break;case "MOVE_Y":context.Position+=new Vector3(0,i.Number,0);break;default:return false;}}return true;}
}
