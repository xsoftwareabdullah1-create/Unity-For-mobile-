// Lightweight smoke-test entry points are kept dependency-free so they can run on CI without a test framework.
using ForgeMobile.Engine.Core;
using ForgeMobile.Engine.Rendering;
using ForgeMobile.Engine.Scripting;

namespace ForgeMobile.Tests;

public static class EngineSmokeTests
{
    public static void RunAll()
    {
        var clock = new EngineClock(); clock.Tick(1.0 / 60.0); if (clock.Frame != 1) throw new Exception("Clock failed");
        var mesh = PrimitiveMeshes.Cube(); if (!mesh.IsValid) throw new Exception("Cube mesh failed");
        var script = ScriptParser.Parse("log(hello);\\nset(speed, 2);\\nmove(1);"); if (!script.IsValid) throw new Exception("Script parse failed");
        var context = new ScriptContext(); if (!ScriptVm.Execute(script, context) || context.Get("speed") != 2) throw new Exception("Script VM failed");
    }
}
