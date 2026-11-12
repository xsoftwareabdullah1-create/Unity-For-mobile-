namespace ForgeMobile.Engine.Editor;

public sealed class EditorLayout
{
    public float HierarchyWidth { get; set; } = 230;
    public float InspectorWidth { get; set; } = 300;
    public float BottomHeight { get; set; } = 220;
    public bool CompactMode { get; set; }
    public void Clamp(){HierarchyWidth=Math.Clamp(HierarchyWidth,150,500);InspectorWidth=Math.Clamp(InspectorWidth,220,600);BottomHeight=Math.Clamp(BottomHeight,100,600);}
}
