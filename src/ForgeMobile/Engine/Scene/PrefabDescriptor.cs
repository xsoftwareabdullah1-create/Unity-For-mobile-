namespace ForgeMobile.Engine.Scene;

public sealed class PrefabDescriptor
{
    public string Id { get; set; } = Guid.NewGuid().ToString("N");
    public string Name { get; set; } = "New Prefab";
    public string SourceSceneId { get; set; } = "";
    public string SerializedEntity { get; set; } = "";

}
