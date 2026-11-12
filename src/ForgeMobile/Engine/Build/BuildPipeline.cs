namespace ForgeMobile.Engine.Build;

public sealed class BuildPipeline
{
    public List<BuildStep> Steps { get; } = new();
    public async Task<BuildReport> Execute(CancellationToken token=default){var report=new BuildReport();foreach(var step in Steps){token.ThrowIfCancellationRequested();report.Messages.Add("Starting: "+step.Name);try{if(!await step.Run(token)){report.Messages.Add("Failed: "+step.Name);report.Success=false;report.FinishedUtc=DateTime.UtcNow;return report;}}catch(Exception ex){report.Messages.Add(step.Name+": "+ex.Message);report.Success=false;report.FinishedUtc=DateTime.UtcNow;return report;}}report.Success=true;report.FinishedUtc=DateTime.UtcNow;return report;}
}
