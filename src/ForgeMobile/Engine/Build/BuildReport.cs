namespace ForgeMobile.Engine.Build;

public sealed class BuildReport
{
    public bool Success { get; set; }
    public string OutputPath { get; set; } = "";
    public DateTime StartedUtc { get; set; } = DateTime.UtcNow;
    public DateTime? FinishedUtc { get; set; }
    public List<string> Messages { get; } = new();
    public TimeSpan Duration=> (FinishedUtc??DateTime.UtcNow)-StartedUtc;
}
