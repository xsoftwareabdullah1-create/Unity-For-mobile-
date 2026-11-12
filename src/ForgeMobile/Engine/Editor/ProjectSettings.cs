namespace ForgeMobile.Engine.Editor;

public sealed class ProjectSettings
{
    public string ProductName { get; set; } = "MyFirstGame";
    public string CompanyName { get; set; } = "Independent Creator";
    public string DefaultScene { get; set; } = "Scenes/Main.scene";
    public int TargetFrameRate { get; set; } = 60;
    public Vector3 Gravity { get; set; } = new(0,-9.81f,0);

}
