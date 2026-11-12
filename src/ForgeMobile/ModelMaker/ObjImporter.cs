using System.Globalization;
using System.Numerics;
namespace ForgeMobile.ModelMaker;

// OBJ geometry importer: vertices and polygon faces (triangulated fan).
// Materials, UV coordinates and external texture libraries are currently skipped.
public static class ObjImporter
{
 public static ModelMesh Read(string path)
 {
  var mesh=new ModelMesh{Name=Path.GetFileNameWithoutExtension(path)};
  foreach(var raw in File.ReadLines(path))
  {
   var line=raw.Trim();if(line.Length==0||line.StartsWith("#"))continue;
   var p=line.Split(' ',StringSplitOptions.RemoveEmptyEntries);
   if(p[0]=="v"&&p.Length>=4)mesh.Vertices.Add(new(float.Parse(p[1],CultureInfo.InvariantCulture),float.Parse(p[2],CultureInfo.InvariantCulture),float.Parse(p[3],CultureInfo.InvariantCulture)));
   else if(p[0]=="f"&&p.Length>=4)
   {
    var ids=p.Skip(1).Select(x=>int.Parse(x.Split('/')[0],CultureInfo.InvariantCulture)).Select(i=>i<0?mesh.Vertices.Count+i:i-1).ToArray();
    for(var i=1;i<ids.Length-1;i++)mesh.Triangles.AddRange(new[]{ids[0],ids[i],ids[i+1]});
   }
  }
  if(!mesh.IsValid)throw new InvalidDataException("OBJ contains no valid triangle mesh.");
  return mesh;
 }
}