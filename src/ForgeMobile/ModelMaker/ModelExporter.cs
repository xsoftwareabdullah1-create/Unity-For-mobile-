using System.Globalization;
using System.Numerics;
using System.Text;
namespace ForgeMobile.ModelMaker;
public static class ModelExporter
{
    private static readonly CultureInfo Inv=CultureInfo.InvariantCulture;
    public static void WriteObj(string path,IReadOnlyList<ModelMesh> meshes)
    {
        var sb=new StringBuilder("# Clear Game Engine OBJ export\n");var offset=1;
        foreach(var m in meshes.Where(x=>x.IsValid))
        {
            sb.Append("o ").Append(Safe(m.Name)).Append('\n');
            foreach(var v in m.Vertices){var p=Transform(v,m);sb.Append("v ").Append(F(p.X)).Append(' ').Append(F(p.Y)).Append(' ').Append(F(p.Z)).Append('\n');}
            for(var i=0;i<m.Triangles.Count;i+=3)sb.Append("f ").Append(m.Triangles[i]+offset).Append(' ').Append(m.Triangles[i+1]+offset).Append(' ').Append(m.Triangles[i+2]+offset).Append('\n');
            offset+=m.Vertices.Count;
        }
        File.WriteAllText(path,sb.ToString(),new UTF8Encoding(false));
    }
    public static void WriteStl(string path,IReadOnlyList<ModelMesh> meshes)
    {
        var sb=new StringBuilder("solid ClearGameEngine\n");
        foreach(var m in meshes.Where(x=>x.IsValid))for(var i=0;i<m.Triangles.Count;i+=3)
        {
            var a=Transform(m.Vertices[m.Triangles[i]],m);var b=Transform(m.Vertices[m.Triangles[i+1]],m);var c=Transform(m.Vertices[m.Triangles[i+2]],m);
            var n=Vector3.Cross(b-a,c-a);if(n.LengthSquared()>1e-12f)n=Vector3.Normalize(n);
            sb.Append(" facet normal ").Append(F(n.X)).Append(' ').Append(F(n.Y)).Append(' ').Append(F(n.Z)).Append("\n  outer loop\n");
            foreach(var v in new[]{a,b,c})sb.Append("   vertex ").Append(F(v.X)).Append(' ').Append(F(v.Y)).Append(' ').Append(F(v.Z)).Append('\n');
            sb.Append("  endloop\n endfacet\n");
        }
        sb.Append("endsolid ClearGameEngine\n");File.WriteAllText(path,sb.ToString(),new UTF8Encoding(false));
    }
    private static Vector3 Transform(Vector3 v,ModelMesh m)=>new(v.X*m.Scale.X+m.Position.X,v.Y*m.Scale.Y+m.Position.Y,v.Z*m.Scale.Z+m.Position.Z);
    private static string F(float v)=>v.ToString("0.######",Inv);
    private static string Safe(string s)=>new(s.Select(c=>char.IsLetterOrDigit(c)||c=='_'?c:'_').ToArray());
}
