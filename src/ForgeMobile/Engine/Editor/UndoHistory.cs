namespace ForgeMobile.Engine.Editor;

public sealed class UndoHistory
{
    private readonly Stack<EditorCommand> _undo=new();
    private readonly Stack<EditorCommand> _redo=new();
    public void Push(EditorCommand command){_undo.Push(command);_redo.Clear();}
    public bool Undo(){if(_undo.Count==0)return false;var c=_undo.Pop();c.Undo();_redo.Push(c);return true;}
    public bool Redo(){if(_redo.Count==0)return false;var c=_redo.Pop();c.Execute();_undo.Push(c);return true;}
}
