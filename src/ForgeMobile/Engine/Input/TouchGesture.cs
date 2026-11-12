namespace ForgeMobile.Engine.Input;

public sealed class TouchGesture
{
    public string Kind { get; set; } = "Tap";
    public Vector2 Start { get; set; }
    public Vector2 Current { get; set; }
    public int PointerCount { get; set; } = 1;
    public Vector2 Delta=>Current-Start;

}
