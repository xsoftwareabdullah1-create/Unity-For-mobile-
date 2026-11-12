namespace ForgeMobile.ModelMaker;

// Curated offline 3D modeling reference. This is a deterministic knowledge guide,
// not a generative LLM; it runs without a network connection or API key.
public sealed record ModelingReply(string Text,string? Script=null,string Topic="general");
public sealed class LocalModelingAssistant
{
 private sealed record Entry(string[] Keys,string Answer,string? Script,string Topic);
 private readonly Entry[] _kb =
 {
  new(new[]{"cube","box","cuboid"}, "A cube is a useful blockout primitive. Scale it to match proportions; beveling and edge loops are separate mesh-edit operations.", "cube Block\nscale Block 2 1 1", "primitives"),
  new(new[]{"sphere","ball","planet"}, "A UV sphere uses latitude rings and longitude segments. Raise segment counts for smooth silhouettes, but keep mobile polygon budgets modest.", "sphere Sphere\nscale Sphere 1 1 1", "primitives"),
  new(new[]{"robot","character","humanoid"}, "Block out a humanoid from separate primitives: torso, head, arms and legs. Align pivots before rigging and skinning.", "cube Torso\nscale Torso 0.8 1.2 0.4\nsphere Head\nmove Head 0 1.1 0\ncube LeftArm\nmove LeftArm -0.7 0.2 0\ncube RightArm\nmove RightArm 0.7 0.2 0\ncube LeftLeg\nmove LeftLeg -0.25 -1.1 0\ncube RightLeg\nmove RightLeg 0.25 -1.1 0", "character"),
  new(new[]{"low poly","mobile","optimization","polygon"}, "For mobile games, prefer low-poly meshes, reuse materials, merge static geometry, use LODs and profile on the target device.", null, "optimization"),
  new(new[]{"uv","texture","unwrap"}, "UV mapping assigns 2D texture coordinates to mesh surfaces. Avoid stretching, leave padding between islands and pack islands into the 0–1 tile. UV editing is not yet implemented.", null, "uv"),
  new(new[]{"normal","topology","faces"}, "Use consistent triangle winding, avoid degenerate faces, keep manifold topology where possible and recalculate normals after mesh edits.", null, "topology"),
  new(new[]{"export","obj","stl","gltf","fbx"}, "OBJ import/export and ASCII STL export are implemented. Full glTF/GLB and FBX import/export still need dedicated parsers and conformance tests.", null, "formats"),
  new(new[]{"import","model","format","blend","dae","3ds","step","usd"}, "This build imports OBJ geometry. Convert other formats to OBJ as a workaround. Blender .blend is a native project file, not a simple interchange mesh.", null, "formats"),
  new(new[]{"script","code","procedural","generate"}, "Modeling DSL: cube NAME, sphere NAME, plane NAME, move NAME X Y Z, scale NAME X Y Z, rotate NAME X Y Z, delete NAME. Use one command per line.", ModelScriptInterpreter.StarterScript, "scripting"),
  new(new[]{"sculpt","brush","subdivide","bevel"}, "Sculpt brushes, bevel, subdivision surfaces and vertex-level editing are advanced tools and are not implemented in this milestone.", null, "mesh-editing")
 };
 public ModelingReply Ask(string question)
 {
  var q=(question??"").ToLowerInvariant();
  var hit=_kb.SelectMany(e=>e.Keys.Select(k=>(Entry:e,Key:k))).Where(x=>q.Contains(x.Key)).OrderByDescending(x=>x.Key.Length).FirstOrDefault();
  if(hit.Entry is not null)return new(hit.Entry.Answer,hit.Entry.Script,hit.Entry.Topic);
  return new("I am the offline Clear modeling guide. Ask about primitives, robot blockouts, mobile optimization, topology, UVs, imports/exports or the modeling command language. I do not use a cloud AI model in this build.",null,"help");
 }
}