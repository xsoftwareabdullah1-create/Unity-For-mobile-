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

        var models=new List<ModelMesh>();
        new ModelScriptInterpreter().Execute("cube Body\nscale Body 1 2 1\nsphere Head\nmove Head 0 1.5 0",models);
        if(models.Count!=2 || Math.Abs(models[0].Scale.Y-2)>0.001f || Math.Abs(models[1].Position.Y-1.5f)>0.001f)
            throw new Exception("Code-to-3D interpreter failed");
        var guide=new LocalModelingAssistant().Ask("How do I make a robot character?");
        if(string.IsNullOrWhiteSpace(guide.Text) || guide.Script is null) throw new Exception("Offline modeling guide failed");
        if(!ModelFormatSupport.Formats.Any(x=>x.Extension==".obj" && x.Status==ModelFormatStatus.Implemented))
            throw new Exception("Model format registry failed");
    }
}
