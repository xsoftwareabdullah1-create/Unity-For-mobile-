namespace ForgeMobile.Engine.Rendering;

public sealed class ShaderDescriptor
{
    public string Name { get; set; } = "New Shader";
    public string VertexSource { get; set; } = "";
    public string FragmentSource { get; set; } = "";
    public string Language { get; set; } = "GLSL ES 3.0";

}
