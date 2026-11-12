namespace ForgeMobile.Engine.Scripting;

public sealed class ScriptScheduler
{
    private readonly List<(ScriptProgram Program,ScriptContext Context)> _scripts=new();
    public void Attach(ScriptProgram program,ScriptContext context)=>_scripts.Add((program,context));
    public int Tick(){var count=0;foreach(var item in _scripts)if(ScriptVm.Execute(item.Program,item.Context))count++;return count;}
    public void Clear()=>_scripts.Clear();
}
