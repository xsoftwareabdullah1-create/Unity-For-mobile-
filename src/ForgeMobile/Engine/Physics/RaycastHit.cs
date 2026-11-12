namespace ForgeMobile.Engine.Physics;

public sealed class RaycastHit
{
    public bool Hit { get; set; }
    public string EntityId { get; set; } = "";
    public Vector3 Point { get; set; }
    public Vector3 Normal { get; set; }
    public float Distance { get; set; }

}
