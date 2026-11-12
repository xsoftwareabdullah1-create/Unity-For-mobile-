namespace ForgeMobile.Engine.Build;

public sealed class BuildStep
{
    public string Name { get; set; } = "Validate";
    public Func<CancellationToken,Task<bool>> Run { get; set; } = _=>Task.FromResult(true);

}
