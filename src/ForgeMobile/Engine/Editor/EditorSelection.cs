namespace ForgeMobile.Engine.Editor;

public sealed class EditorSelection
{
    public List<string> SelectedIds { get; } = new();
    public string? ActiveId => SelectedIds.LastOrDefault();
    public void Select(string id,bool additive=false){if(!additive)SelectedIds.Clear();if(!SelectedIds.Contains(id))SelectedIds.Add(id);}
    public void Clear()=>SelectedIds.Clear();
}
