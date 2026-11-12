namespace ForgeMobile.Engine.Rendering;

public sealed class MeshData
{
    public string Name { get; set; } = "Mesh";
    public List<VertexData> Vertices { get; set; } = new();
    public List<int> Indices { get; set; } = new();
    public bool IsValid => Vertices.Count > 0 && Indices.Count >= 3 && Indices.All(i => i >= 0 && i < Vertices.Count);
}
