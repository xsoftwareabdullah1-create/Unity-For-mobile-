namespace ForgeMobile.Engine.Scene;

public sealed class SceneEntity
{
    public string Id { get; set; } = Guid.NewGuid().ToString("N");
    public string Name { get; set; } = "GameObject";
    public string ParentId { get; set; } = "";
    public bool Active { get; set; } = true;
    public SceneTransform Transform { get; set; } = new();
    public List<SceneComponent> Components { get; } = new();
    public T Add<T>(T component) where T : SceneComponent { Components.Add(component); return component; }
    public T? Get<T>() where T : SceneComponent => Components.OfType<T>().FirstOrDefault();
}
