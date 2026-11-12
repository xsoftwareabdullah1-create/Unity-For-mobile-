namespace ForgeMobile.Engine.Rendering;

public sealed class RenderQueue
{
    private readonly List<RenderCommand> _commands = new();
    public IReadOnlyList<RenderCommand> Commands => _commands;
    public void Enqueue(RenderCommand command) => _commands.Add(command);
    public void SortByMaterial() { _commands.Sort((a,b)=>string.CompareOrdinal(a.MaterialId,b.MaterialId)); }
    public void Clear() => _commands.Clear();
}
