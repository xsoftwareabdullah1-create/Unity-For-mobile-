namespace ForgeMobile.Engine.Rendering;

public sealed class RenderDevice
{
    public string Backend { get; set; } = "OpenGL ES (planned adapter)";
    public bool IsInitialized { get; private set; }
    public string Status { get; private set; } = "Not initialized";
    public void MarkInitialized(string backend) { Backend=backend; IsInitialized=true; Status="Ready"; }
    public void MarkUnavailable(string reason) { IsInitialized=false; Status=reason; }
}
