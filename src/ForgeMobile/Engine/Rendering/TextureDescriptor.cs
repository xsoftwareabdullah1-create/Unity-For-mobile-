namespace ForgeMobile.Engine.Rendering;

public sealed class TextureDescriptor
{
    public string Id { get; set; } = Guid.NewGuid().ToString("N");
    public int Width { get; set; } = 1;
    public int Height { get; set; } = 1;
    public string Format { get; set; } = "RGBA8";
    public bool Mipmaps { get; set; }

}
