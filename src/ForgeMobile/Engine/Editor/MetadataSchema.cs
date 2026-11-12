namespace ForgeMobile.Engine.Editor;

public sealed class MetadataSchema
{
    public string TypeName { get; set; } = "GameObject";
    public List<MetadataField> Fields { get; } = new();
    public IEnumerable<MetadataField> Grouped(string group)=>Fields.Where(x=>x.Group==group);
}
