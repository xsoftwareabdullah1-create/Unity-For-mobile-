namespace ForgeMobile.Engine.Core;

public sealed class EngineConfiguration
{
    public string ProjectName { get; set; } = "MyFirstGame";
    public int TargetFps { get; set; } = 60;
    public bool VSync { get; set; } = true;
    public bool Autosave { get; set; } = true;
    public int AutosaveSeconds { get; set; } = 60;
    public void Clamp() { TargetFps = Math.Clamp(TargetFps, 15, 240); AutosaveSeconds = Math.Clamp(AutosaveSeconds, 10, 600); }
}
