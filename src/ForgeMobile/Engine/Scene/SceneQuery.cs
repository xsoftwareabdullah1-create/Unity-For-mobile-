namespace ForgeMobile.Engine.Scene;

public sealed class SceneQuery
{
    private readonly SceneGraph _scene;
    public SceneQuery(SceneGraph scene) => _scene = scene;
    public IEnumerable<SceneEntity> ByName(string text) => _scene.Entities.Where(x => x.Name.Contains(text, StringComparison.OrdinalIgnoreCase));
    public IEnumerable<SceneEntity> ActiveOnly() => _scene.Entities.Where(x => x.Active);
    public IEnumerable<SceneEntity> WithComponent<T>() where T : SceneComponent => _scene.Entities.Where(x => x.Get<T>() != null);
}
