namespace ForgeMobile.Engine.Editor;

public sealed class ConsoleMessage
{
    public DateTime Time { get; set; } = DateTime.Now;
    public string Level { get; set; } = "Info";
    public string Text { get; set; } = "";
    public string Source { get; set; } = "Editor";

}
