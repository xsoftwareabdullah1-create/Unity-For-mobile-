namespace ForgeMobile.Engine.Scene;

public sealed class SceneSnapshot
{
    public DateTime CapturedUtc { get; } = DateTime.UtcNow;
    public List<SceneEntity> Entities { get; set; } = new();

}
