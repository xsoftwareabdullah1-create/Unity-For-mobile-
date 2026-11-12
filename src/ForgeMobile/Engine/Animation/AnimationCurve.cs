namespace ForgeMobile.Engine.Animation;

public sealed class AnimationCurve
{
    public List<AnimationKeyframe> Keys { get; } = new();
    public float Evaluate(float time){if(Keys.Count==0)return 0;var sorted=Keys.OrderBy(x=>x.Time).ToArray();if(time<=sorted[0].Time)return sorted[0].Value;if(time>=sorted[^1].Time)return sorted[^1].Value;for(var i=0;i<sorted.Length-1;i++){var a=sorted[i];var b=sorted[i+1];if(time>=a.Time&&time<=b.Time){var t=(time-a.Time)/Math.Max(.0001f,b.Time-a.Time);return a.Value+(b.Value-a.Value)*t;}}return 0;}
}
