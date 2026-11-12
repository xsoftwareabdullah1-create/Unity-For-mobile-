namespace ForgeMobile.Engine.Editor;

public sealed class InspectorProperty
{
    public string Key { get; set; } = "";
    public string Label { get; set; } = "Property";
    public string Value { get; set; } = "";
    public string Kind { get; set; } = "Text";
    public string? Tooltip { get; set; }
    public bool ReadOnly { get; set; }

}
