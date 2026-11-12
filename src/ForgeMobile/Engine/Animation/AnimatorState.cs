namespace ForgeMobile.Engine.Animation;

public sealed class AnimatorState
{
    public string Name { get; set; } = "Idle";
    public string ClipId { get; set; } = "";
    public bool Loop { get; set; } = true;
    public float Speed { get; set; } = 1;
    public float Time { get; set; }
    public void Advance(float delta,float duration){if(duration<=0)return;Time+=delta*Speed;if(Loop)Time%=duration;else Time=Math.Min(Time,duration);}
}
