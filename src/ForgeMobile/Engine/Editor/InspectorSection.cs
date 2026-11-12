namespace ForgeMobile.Engine.Editor;

public sealed class InspectorSection
{
    public string Title { get; set; } = "Section";
    public string Icon { get; set; } = "settings";
    public bool Expanded { get; set; } = true;
    public List<InspectorProperty> Properties { get; } = new();

}
