namespace ForgeMobile.Engine.Rendering;

public sealed class ProjectionMath
{

    public static Vector3 Project(Vector3 point, Matrix4x4 viewProjection, int width, int height) { var p = Vector4.Transform(new Vector4(point,1), viewProjection); if (Math.Abs(p.W) < 1e-6f) return Vector3.Zero; var n = new Vector3(p.X,p.Y,p.Z)/p.W; return new Vector3((n.X+1)*.5f*width,(1-n.Y)*.5f*height,n.Z); }
}
