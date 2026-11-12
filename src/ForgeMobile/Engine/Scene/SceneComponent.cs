namespace ForgeMobile.Engine.Scene;

public class SceneComponent
{
    public string Id { get; set; } = Guid.NewGuid().ToString("N");
    public bool Enabled { get; set; } = true;
    public virtual string DisplayName => GetType().Name;

}
