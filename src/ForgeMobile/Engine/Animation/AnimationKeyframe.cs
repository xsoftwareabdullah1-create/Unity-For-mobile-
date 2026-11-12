namespace ForgeMobile.Engine.Animation;

public sealed class AnimationKeyframe
{
    public float Time { get; set; }
    public float Value { get; set; }
    public string Interpolation { get; set; } = "Linear";

}
