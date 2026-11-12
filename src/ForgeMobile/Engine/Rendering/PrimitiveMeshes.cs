namespace ForgeMobile.Engine.Rendering;

public sealed class PrimitiveMeshes
{

    public static MeshData Cube(float size = 1) { var h=size*.5f; var v=new List<VertexData>(); foreach(var p in new[]{new Vector3(-h,-h,-h),new Vector3(h,-h,-h),new Vector3(h,h,-h),new Vector3(-h,h,-h),new Vector3(-h,-h,h),new Vector3(h,-h,h),new Vector3(h,h,h),new Vector3(-h,h,h)}) v.Add(new VertexData{Position=p}); return new MeshData{Name="Cube",Vertices=v,Indices=new(){0,2,1,0,3,2,4,5,6,4,6,7,0,1,5,0,5,4,2,3,7,2,7,6,1,2,6,1,6,5,3,0,4,3,4,7}}; }
    public static MeshData Plane(float size=10) => new(){Name="Plane",Vertices=new(){new(){Position=new(-size/2,0,-size/2)},new(){Position=new(size/2,0,-size/2)},new(){Position=new(size/2,0,size/2)},new(){Position=new(-size/2,0,size/2)}},Indices=new(){0,2,1,0,3,2}};
}
