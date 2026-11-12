namespace ForgeMobile.Engine.Scene;

public sealed class SceneGraph
{
    public List<SceneEntity> Entities { get; } = new();
    public SceneEntity Create(string name) { var entity = new SceneEntity { Name = name }; Entities.Add(entity); return entity; }
    public bool Destroy(string id) => Entities.RemoveAll(x => x.Id == id) > 0;
    public SceneEntity? Find(string id) => Entities.FirstOrDefault(x => x.Id == id);
    public IEnumerable<SceneEntity> ChildrenOf(string parentId) => Entities.Where(x => x.ParentId == parentId);
}
