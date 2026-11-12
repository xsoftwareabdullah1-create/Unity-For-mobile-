namespace ForgeMobile.Engine.Editor;

public sealed class DockPanel
{
    public string Id { get; set; } = "project";
    public string Title { get; set; } = "Project";
    public bool Visible { get; set; } = true;
    public float PreferredSize { get; set; } = 240;
    public bool Scrollable { get; set; } = true;

}
