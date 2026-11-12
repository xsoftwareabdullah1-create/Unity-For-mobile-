namespace ForgeMobile.Engine.Core;

public sealed class EngineState
{
    public bool IsRunning { get; private set; }
    public bool IsPaused { get; private set; }
    public void Start() { IsRunning = true; IsPaused = false; }
    public void Pause() { if (IsRunning) IsPaused = true; }
    public void Resume() { if (IsRunning) IsPaused = false; }
    public void Stop() { IsRunning = false; IsPaused = false; }
}
