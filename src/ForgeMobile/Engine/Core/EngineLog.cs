namespace ForgeMobile.Engine.Core;

public sealed class EngineLog
{
    private readonly List<string> _entries = new();
    public IReadOnlyList<string> Entries => _entries;
    public void Write(string level, string message) { _entries.Add($"[{DateTime.Now:HH:mm:ss}] [{level}] {message}"); if (_entries.Count > 2000) _entries.RemoveAt(0); }
    public void Clear() => _entries.Clear();
}
