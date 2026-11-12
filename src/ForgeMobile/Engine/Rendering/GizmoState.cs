namespace ForgeMobile.Engine.Rendering;

public sealed class GizmoState
{
    public string Tool { get; set; } = "Move";
    public string CoordinateSpace { get; set; } = "World";
    public string PivotMode { get; set; } = "Center";
    public bool Snapping { get; set; }
    public float SnapStep { get; set; } = 1;

}
