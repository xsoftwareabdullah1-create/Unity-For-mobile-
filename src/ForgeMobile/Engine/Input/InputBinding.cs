namespace ForgeMobile.Engine.Input;

public sealed class InputBinding
{
    public string Action { get; set; } = "";
    public string Device { get; set; } = "Touch";
    public string Control { get; set; } = "Tap";
    public float Scale { get; set; } = 1;

}
