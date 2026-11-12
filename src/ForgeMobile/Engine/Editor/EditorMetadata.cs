namespace ForgeMobile.Engine.Editor;

public sealed class EditorMetadata
{
    public string DisplayName { get; set; } = "GameObject";
    public string Icon { get; set; } = "cube";
    public string Category { get; set; } = "General";
    public string Tooltip { get; set; } = "";
    public string Tag { get; set; } = "Untagged";
    public string Layer { get; set; } = "Default";
    public bool Active { get; set; } = true;
    public bool Static { get; set; }

}
