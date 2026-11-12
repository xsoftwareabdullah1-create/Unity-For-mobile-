namespace ForgeMobile.Engine.Editor;

public sealed class EditorTool
{
    public string Active { get; private set; } = "Move";
    public string[] Available { get; } = new[] { "Hand", "Move", "Rotate", "Scale", "Rect" };
    public void Set(string tool){if(!Available.Contains(tool))throw new ArgumentOutOfRangeException(nameof(tool));Active=tool;}
}
