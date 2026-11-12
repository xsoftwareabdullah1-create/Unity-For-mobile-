namespace ForgeMobile.Engine.Scripting;

public sealed class ScriptAsset
{
    public string Id { get; set; } = Guid.NewGuid().ToString("N");
    public string Name { get; set; } = "NewBehaviour.cs";
    public string Source { get; set; } = "// Forge safe script subset\\nlog(\\\"Hello from Forge\\\");";
    public DateTime ModifiedUtc { get; set; } = DateTime.UtcNow;

}
