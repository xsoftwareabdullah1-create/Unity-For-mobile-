namespace ForgeMobile.Engine.Scene;

public sealed class SceneMetadata
{
    public string Author { get; set; } = "";
    public string Description { get; set; } = "";
    public string SceneGuid { get; set; } = Guid.NewGuid().ToString("N");
    public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
    public DateTime ModifiedUtc { get; set; } = DateTime.UtcNow;
    public Dictionary<string,string> Labels { get; set; } = new();

}
