using ForgeMobile.ModelMaker;

namespace ForgeMobile.Tests;

public static class ModelMakerSmokeTests
{
    public static void Run()
    {
        var cube=PrimitiveFactory.Cube();
        if(!cube.IsValid || cube.Vertices.Count!=8) throw new Exception("Cube primitive invalid");
        var sphere=PrimitiveFactory.UvSphere();
        if(!sphere.IsValid) throw new Exception("UV sphere invalid");
        var plane=PrimitiveFactory.Plane();
        if(!plane.IsValid) throw new Exception("Plane primitive invalid");
        var obj=Path.Combine(Path.GetTempPath(),"clear-engine-smoke.obj");
        ModelExporter.WriteObj(obj,new[]{cube});
        if(!File.ReadAllText(obj).Contains("f 1 3 2")) throw new Exception("OBJ export invalid");
        File.Delete(obj);
        var stl=Path.Combine(Path.GetTempPath(),"clear-engine-smoke.stl");
        ModelExporter.WriteStl(stl,new[]{plane});
        if(!File.ReadAllText(stl).Contains("endsolid ClearGameEngine")) throw new Exception("STL export invalid");
        File.Delete(stl);
    }
}
