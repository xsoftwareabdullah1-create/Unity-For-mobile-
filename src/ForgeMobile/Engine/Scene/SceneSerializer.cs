namespace ForgeMobile.Engine.Scene;

public sealed class SceneSerializer
{

    private static readonly System.Text.Json.JsonSerializerOptions Options = new() { WriteIndented = true };
    public static string Serialize(SceneGraph graph) => System.Text.Json.JsonSerializer.Serialize(graph, Options);
    public static SceneGraph Deserialize(string json) => System.Text.Json.JsonSerializer.Deserialize<SceneGraph>(json, Options) ?? new SceneGraph();
}
