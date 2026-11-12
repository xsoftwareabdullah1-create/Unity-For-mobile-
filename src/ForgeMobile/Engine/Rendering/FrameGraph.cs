namespace ForgeMobile.Engine.Rendering;

public sealed class FrameGraph
{
    public List<RenderPassDescriptor> Passes { get; } = new();
    public void Add(RenderPassDescriptor pass)=>Passes.Add(pass);
    public IReadOnlyList<RenderPassDescriptor> Ordered()=>Passes.OrderBy(x=>x.Order).ToArray();
}
