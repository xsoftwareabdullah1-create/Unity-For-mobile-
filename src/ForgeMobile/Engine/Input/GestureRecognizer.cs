namespace ForgeMobile.Engine.Input;

public sealed class GestureRecognizer
{
    private Vector2 _last;
    public Vector2 Delta { get; private set; }
    public float PinchDelta { get; private set; }
    public void Begin(Vector2 point){_last=point;Delta=Vector2.Zero;}
    public void Move(Vector2 point){Delta=point-_last;_last=point;}
    public void Pinch(float previousDistance,float currentDistance)=>PinchDelta=currentDistance-previousDistance;
}
