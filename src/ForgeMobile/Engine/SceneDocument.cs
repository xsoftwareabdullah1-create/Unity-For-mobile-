using System.Text.Json.Serialization;

namespace ForgeMobile.Engine;

public sealed class SceneDocument
{
    public int SchemaVersion { get; set; } = 1;
    public string Name { get; set; } = "Main Scene";
    public List<SceneObject> Objects { get; set; } = new();
    public string ActiveCameraId { get; set; } = "";
    public DateTime ModifiedUtc { get; set; } = DateTime.UtcNow;

    public static SceneDocument CreateDefault()
    {
        var scene = new SceneDocument();
        scene.Objects.Add(SceneObject.Create("Main Camera", "Camera"));
        scene.Objects.Add(SceneObject.Create("Directional Light", "Light"));
        scene.Objects.Add(SceneObject.Create("Cube", "Mesh"));
        scene.ActiveCameraId = scene.Objects[0].Id;
        return scene;
    }

    public SceneObject? Find(string id) => Objects.FirstOrDefault(item => item.Id == id);

    public SceneObject Add(string name, string type)
    {
        var item = SceneObject.Create(name, type);
        Objects.Add(item);
        ModifiedUtc = DateTime.UtcNow;
        return item;
    }

    public bool Remove(string id)
    {
        var removed = Objects.RemoveAll(item => item.Id == id) > 0;
        if (removed) ModifiedUtc = DateTime.UtcNow;
        return removed;
    }
}

public sealed class SceneObject
{
    public string Id { get; set; } = Guid.NewGuid().ToString("N");
    public string Name { get; set; } = "GameObject";
    public string Type { get; set; } = "Empty";
    public bool Enabled { get; set; } = true;
    public string ParentId { get; set; } = "";
    public TransformData Transform { get; set; } = new();
    public List<string> Components { get; set; } = new();

    public static SceneObject Create(string name, string type)
    {
        var item = new SceneObject { Name = name, Type = type };
        item.Components.Add("Transform");
        if (type == "Mesh") item.Components.Add("Mesh Renderer");
        if (type == "Camera") item.Components.Add("Camera");
        if (type == "Light") item.Components.Add("Light");
        return item;
    }

    public SceneObject Clone() => new()
    {
        Id = Guid.NewGuid().ToString("N"),
        Name = Name + " Copy",
        Type = Type,
        Enabled = Enabled,
        ParentId = ParentId,
        Transform = new TransformData
        {
            X = Transform.X + 1, Y = Transform.Y, Z = Transform.Z,
            RotationX = Transform.RotationX, RotationY = Transform.RotationY, RotationZ = Transform.RotationZ,
            ScaleX = Transform.ScaleX, ScaleY = Transform.ScaleY, ScaleZ = Transform.ScaleZ
        },
        Components = new List<string>(Components)
    };
}

public sealed class TransformData
{
    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }
    public float RotationX { get; set; }
    public float RotationY { get; set; }
    public float RotationZ { get; set; }
    public float ScaleX { get; set; } = 1;
    public float ScaleY { get; set; } = 1;
    public float ScaleZ { get; set; } = 1;
}
