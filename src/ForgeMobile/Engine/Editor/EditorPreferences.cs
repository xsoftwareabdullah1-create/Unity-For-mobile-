namespace ForgeMobile.Engine.Editor;

public sealed class EditorPreferences
{
    public bool DarkTheme { get; set; } = true;
    public bool ShowTooltips { get; set; } = true;
    public bool AutoSave { get; set; } = true;
    public bool ConfirmDelete { get; set; } = true;
    public float UiScale { get; set; } = 1;
    public string Language { get; set; } = "en";
    public void Clamp()=>UiScale=Math.Clamp(UiScale,.75f,1.5f);
}
