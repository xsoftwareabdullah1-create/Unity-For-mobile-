namespace ForgeMobile.Engine.Input;

public sealed class InputAction
{
    public string Name { get; set; } = "Jump";
    public string Kind { get; set; } = "Button";
    public float Value { get; set; }
    public bool Pressed { get; set; }

}
