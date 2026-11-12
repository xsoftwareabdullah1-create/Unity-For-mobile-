namespace ForgeMobile.Engine.Rendering;

public sealed class GridBuilder
{

    public static IEnumerable<(Vector3 A,Vector3 B)> Build(int halfLines=20,float spacing=1) { for(var i=-halfLines;i<=halfLines;i++){ yield return (new Vector3(i*spacing,0,-halfLines*spacing),new Vector3(i*spacing,0,halfLines*spacing)); yield return (new Vector3(-halfLines*spacing,0,i*spacing),new Vector3(halfLines*spacing,0,i*spacing)); } }
}
