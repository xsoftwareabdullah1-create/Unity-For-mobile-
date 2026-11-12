namespace ForgeMobile.Engine.Scene;

public sealed class SceneHistory
{
    private readonly Stack<string> _undo = new();
    private readonly Stack<string> _redo = new();
    public bool CanUndo => _undo.Count > 0;
    public bool CanRedo => _redo.Count > 0;
    public void Push(string snapshot) { _undo.Push(snapshot); _redo.Clear(); }
    public string? Undo(string current) { if (!CanUndo) return null; _redo.Push(current); return _undo.Pop(); }
    public string? Redo(string current) { if (!CanRedo) return null; _undo.Push(current); return _redo.Pop(); }
}
