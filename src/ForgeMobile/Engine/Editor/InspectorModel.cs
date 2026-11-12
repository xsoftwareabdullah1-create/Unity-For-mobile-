namespace ForgeMobile.Engine.Editor;

public sealed class InspectorModel
{
    public string ObjectName { get; set; } = "GameObject";
    public string ObjectType { get; set; } = "Empty";
    public string ObjectId { get; set; } = "";
    public List<InspectorSection> Sections { get; } = new();
    public int PropertyCount=>Sections.Sum(x=>x.Properties.Count);
    public InspectorSection AddSection(string title,string icon){var s=new InspectorSection{Title=title,Icon=icon};Sections.Add(s);return s;}
}
