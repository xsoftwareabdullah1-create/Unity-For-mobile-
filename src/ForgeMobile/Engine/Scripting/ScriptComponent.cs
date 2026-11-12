namespace ForgeMobile.Engine.Scripting;

public sealed class ScriptComponent
{
    public string ScriptAssetId { get; set; } = "";
    public bool Enabled { get; set; } = true;
    public string LastStatus { get; set; } = "Not run";

}
