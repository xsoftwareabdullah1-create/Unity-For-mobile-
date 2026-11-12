namespace ForgeMobile.Engine.Core;

public sealed class ValidationResult
{
    public List<string> Errors { get; } = new();
    public bool IsValid => Errors.Count == 0;
    public void Add(string message) => Errors.Add(message);
    public void ThrowIfInvalid() { if (!IsValid) throw new InvalidOperationException(string.Join(Environment.NewLine, Errors)); }
}
