using System.Globalization;
using System.Numerics;
namespace ForgeMobile.ModelMaker;

// Small deterministic modeling DSL. Commands: cube NAME, sphere NAME, plane NAME,
// move NAME X Y Z, scale NAME X Y Z, rotate NAME X Y Z, delete NAME.
public sealed class ModelScriptInterpreter
{
 public IReadOnlyList<ModelMesh> Execute(string source,IList<ModelMesh> scene)
 {
  var output=new List<ModelMesh>();
  var lineNo=0;
  foreach(var raw in source.Split('\n'))
  {
   lineNo++;var line=raw.Trim();if(line.Length==0||line.StartsWith("#")||line.StartsWith("//"))continue;
   var p=line.Split(' ',StringSplitOptions.RemoveEmptyEntries);var op=p[0].ToLowerInvariant();
   string Arg(int i)=>p.Length>i?p[i]:throw new FormatException($"Line {lineNo}: missing argument {i}.");
   float Num(int i)=>float.Parse(Arg(i),CultureInfo.InvariantCulture);
   ModelMesh Find()=>scene.FirstOrDefault(x=>x.Name.Equals(Arg(1),StringComparison.OrdinalIgnoreCase))??throw new InvalidOperationException($"Line {lineNo}: object '{Arg(1)}' not found.");
   switch(op)
   {
    case "cube": case "sphere": case "plane":
     if(p.Length<2)throw new FormatException($"Line {lineNo}: use {op} NAME.");
     var mesh=op switch{"cube"=>PrimitiveFactory.Cube(),"sphere"=>PrimitiveFactory.UvSphere(),"plane"=>PrimitiveFactory.Plane(),_=>throw new InvalidOperationException()};
     mesh.Name=Arg(1);scene.Add(mesh);output.Add(mesh);break;
    case "move": case "scale": case "rotate":
     if(p.Length!=5)throw new FormatException($"Line {lineNo}: use {op} NAME X Y Z.");
     var target=Find();var v=new Vector3(Num(2),Num(3),Num(4));
     if(op=="move")target.Position=v;else if(op=="scale")target.Scale=v;else target.Rotation=v;break;
    case "delete": if(p.Length!=2)throw new FormatException($"Line {lineNo}: use delete NAME.");var found=Find();scene.Remove(found);break;
    default:throw new NotSupportedException($"Line {lineNo}: unknown command '{op}'.");
   }
  }
  return output;
 }
 public static string StarterScript=>string.Join((char)10,new[]{"# Create a small robot","cube Body","scale Body 1 1.4 0.6","sphere Head","move Head 0 1.2 0","cube LeftArm","move LeftArm -0.8 0.2 0","cube RightArm","move RightArm 0.8 0.2 0"});
}