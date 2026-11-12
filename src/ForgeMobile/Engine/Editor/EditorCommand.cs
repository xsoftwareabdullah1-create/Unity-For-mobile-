namespace ForgeMobile.Engine.Editor;

public sealed class EditorCommand
{
    public string Name { get; set; } = "Command";
    public Action Execute { get; set; } = ()=>{};
    public Action Undo { get; set; } = ()=>{};

}
