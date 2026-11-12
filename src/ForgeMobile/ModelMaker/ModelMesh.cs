using System.Numerics;
namespace ForgeMobile.ModelMaker;
public sealed class ModelMesh
{
    public string Name { get; set; } = "Mesh";
    public List<Vector3> Vertices { get; set; } = new();
    public List<int> Triangles { get; set; } = new();
    public Vector3 Position { get; set; }
    public Vector3 Rotation { get; set; }
    public Vector3 Scale { get; set; } = Vector3.One;
    public bool IsValid => Vertices.Count >= 3 && Triangles.Count >= 3 && Triangles.Count % 3 == 0 && Triangles.All(i => i >= 0 && i < Vertices.Count);
}
public static class PrimitiveFactory
{
    public static ModelMesh Cube() => new() { Name="Cube", Vertices=new() { new(-.5f,-.5f,-.5f),new(.5f,-.5f,-.5f),new(.5f,.5f,-.5f),new(-.5f,.5f,-.5f),new(-.5f,-.5f,.5f),new(.5f,-.5f,.5f),new(.5f,.5f,.5f),new(-.5f,.5f,.5f) }, Triangles=new() { 0,2,1,0,3,2,4,5,6,4,6,7,0,1,5,0,5,4,2,3,7,2,7,6,1,2,6,1,6,5,3,0,4,3,4,7 } };
    public static ModelMesh Plane() => new() { Name="Plane", Vertices=new(){new(-.5f,0,-.5f),new(.5f,0,-.5f),new(.5f,0,.5f),new(-.5f,0,.5f)}, Triangles=new(){0,2,1,0,3,2} };
    public static ModelMesh UvSphere(int rings=12,int segments=20)
    {
        rings=Math.Clamp(rings,4,48); segments=Math.Clamp(segments,8,96);
        var m=new ModelMesh{Name="Sphere"};
        for(var y=0;y<=rings;y++){var v=y/(float)rings;var phi=v*MathF.PI;for(var x=0;x<=segments;x++){var u=x/(float)segments;var theta=u*MathF.PI*2;m.Vertices.Add(new(MathF.Sin(phi)*MathF.Cos(theta)*.5f,MathF.Cos(phi)*.5f,MathF.Sin(phi)*MathF.Sin(theta)*.5f));}}
        for(var y=0;y<rings;y++)for(var x=0;x<segments;x++){var a=y*(segments+1)+x;var b=a+segments+1;m.Triangles.AddRange(new[]{a,b,a+1,a+1,b,b+1});}
        return m;
    }
}
