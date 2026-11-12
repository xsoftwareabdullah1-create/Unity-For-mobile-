namespace ForgeMobile.ModelMaker;

// Offline rule/knowledge assistant. This is not an LLM: it provides curated modeling
// guidance and executable DSL snippets without network access or API keys.
public sealed record ModelingReply(string Text,string? Script=null,string Topic="general");
public sealed class LocalModelingAssistant
{
 private readonly (string[] Keys,string Answer,string? Script,string Topic)[] _kb=
 {
  (new[]{"cube","box","cuboid"},"Use a cube as a blockout primitive. Scale it to the target proportions, then add bevels in a later mesh-edit workflow.","cube Block\nscale Block 2 1 1","primitives"),
  (new[]{"sphere","ball","planet"},"A UV sphere is built from latitude rings and longitude segments. Increase segments for smoother silhouettes; keep mobile polygon budgets modest.","sphere Sphere\nscale Sphere 1 1 1","primitives"),
  (new[]{"robot","character","humanoid"},"Block out a humanoid from separate primitives first: torso, head, two arms and two legs. Align pivots before rigging.","cube Torso\nscale Torso 0.8 1.2 0.4\nsphere Head\nmove Head 0 1.1 0\ncube LeftArm\nmove LeftArm -0.7 0.2 0\ncube RightArm\nmove RightArm 0.7 0.2 0\ncube LeftLeg\nmove LeftLeg -0.25 -1.1 0\ncube RightLeg\nmove RightLeg 0.25 -1.1 0","character"),
  (new[]{"low poly","mobile","optimization","polygon"},"For mobile games, prefer low-poly meshes, reuse materials, merge static geometry, use LODs and keep texture dimensions appropriate to screen size. Profile on the target device.",null,"optimization"),
  (new[]{"uv","texture","unwrap"},"UV mapping assigns 2D texture coordinates to mesh surfaces. Avoid stretching, leave padding between islands and pack islands into the 0–1 tile. UV editing is not yet available in this build.",null,"uv"),
  (new[]{"normal","topology","faces"},"Use consistent triangle winding, avoid degenerate faces, keep manifold topology where possible and recalculate normals after mesh edits.",null,"topology"),
  (new[]{"export","obj","stl","gltf","fbx"},"OBJ and ASCII STL export are implemented. This build does not yet include complete GLB/FBX import/export; those formats require dedicated parsers and conformance testing.",null,"formats"),
  (new[]{"import","model","format","blend","dae","3ds","step","usd"},"The importer currently supports Wavefront OBJ geometry. Other formats need a dedicated parser or an external conversion to OBJ/glTF; Blender .blend files are native project files and cannot be treated as a simple mesh format.",null,"formats"),
  (new[]{"script","code","procedural","generate"},"Use the built-in modeling DSL: cube NAME, sphere NAME, plane NAME, move NAME X Y Z, scale NAME X Y Z, rotate NAME X Y Z and delete NAME. One command per line.",ModelScriptInterpreter.StarterScript,"scripting"),
  (new[]{"sculpt","brush","subdivide","bevel"},"Sculpt brushes, bevel, subdivision surfaces and vertex-level editing are advanced mesh tools and are not implemented in this first integrated milestone.",null,"mesh-editing")
 };
 public ModelingReply Ask(string question)
 {
  var q=question.ToLowerInvariant();
  var hit=_kb.SelectMany(x=>x.Keys.Select(k=>(Entry:x,Key:k))).Where(x=>q.Contains(x.Key)).OrderByDescending(x=>x.Key.Length).FirstOrDefault();
  if(hit.Entry.Answer is not null)return new(hit.Entry.Answer,hit.Entry.Script,hit.Entry.Topic);
  return new("I am the offline Clear modeling guide. Ask about primitives, robot blockouts, mobile optimization, topology, UVs, imports/exports or the modeling command language. I do not use a cloud AI model in this build.",null,"help");
 }
}