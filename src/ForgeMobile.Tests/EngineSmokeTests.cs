using ForgeMobile.Engine.Core;
using ForgeMobile.Engine.Rendering;
using ForgeMobile.Engine.Scripting;
using ForgeMobile.Engine.Scene;

namespace ForgeMobile.Tests;

public static class EngineSmokeTests
{
    public static void RunAll()
    {
        ModelMakerSmokeTests.Run();
        var clock = new EngineClock(); clock.Tick(1d / 60d); if (clock.Frame != 1) throw new Exception("Clock failed");
        var mesh = PrimitiveMeshes.Cube(); if (!mesh.IsValid) throw new Exception("Cube mesh failed");
        var source = string.Join((char)10, new[] { "log(hello);", "set(speed, 2);", "move(1);" });
        var script = ScriptParser.Parse(source); if (!script.IsValid) throw new Exception("Script parse failed");
        var context = new ScriptContext(); if (!ScriptVm.Execute(script, context) || context.Get("speed") != 2) throw new Exception("Script VM failed");
        var scene = new SceneGraph(); var entity = scene.Create("Test Cube"); if (scene.Find(entity.Id) is null) throw new Exception("Scene graph failed");
    }
}
