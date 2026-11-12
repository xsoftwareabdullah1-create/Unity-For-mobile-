using System.Text.Json;
using ForgeMobile.Engine;

namespace ForgeMobile.Services;

public sealed class ProjectStore
{
    private readonly string _root;
    private readonly JsonSerializerOptions _json = new() { WriteIndented = true, PropertyNameCaseInsensitive = true };

    public ProjectStore(string filesDirectory)
    {
        _root = Path.Combine(filesDirectory, "ForgeProjects");
        Directory.CreateDirectory(_root);
    }

    public string CurrentProjectPath => Path.Combine(_root, "MyFirstGame");
    public string ScenePath => Path.Combine(CurrentProjectPath, "Scenes", "MainScene.json");
    public string ScriptsPath => Path.Combine(CurrentProjectPath, "Scripts");
    public string AssetsPath => Path.Combine(CurrentProjectPath, "Assets");
    public string NativePath => Path.Combine(CurrentProjectPath, "Native");

    public void CreateProject(string name = "MyFirstGame")
    {
        var project = Path.Combine(_root, SafeName(name));
        Directory.CreateDirectory(Path.Combine(project, "Scenes"));
        Directory.CreateDirectory(Path.Combine(project, "Scripts"));
        Directory.CreateDirectory(Path.Combine(project, "Assets"));
        Directory.CreateDirectory(Path.Combine(project, "Native"));
        SaveScene(SceneDocument.CreateDefault(), Path.Combine(project, "Scenes", "MainScene.json"));
        WriteStarterFiles(project);
    }

    public void EnsureProject()
    {
        if (!File.Exists(ScenePath)) CreateProject();
        Directory.CreateDirectory(ScriptsPath);
        Directory.CreateDirectory(AssetsPath);
        Directory.CreateDirectory(NativePath);
        WriteStarterFiles(CurrentProjectPath);
    }

    public void SaveScene(SceneDocument scene, string? path = null)
    {
        var destination = path ?? ScenePath;
        Directory.CreateDirectory(Path.GetDirectoryName(destination)!);
        scene.ModifiedUtc = DateTime.UtcNow;
        var temp = destination + ".tmp";
        File.WriteAllText(temp, JsonSerializer.Serialize(scene, _json));
        File.Move(temp, destination, true);
    }

    public SceneDocument LoadScene()
    {
        EnsureProject();
        try { return JsonSerializer.Deserialize<SceneDocument>(File.ReadAllText(ScenePath), _json) ?? SceneDocument.CreateDefault(); }
        catch
        {
            var recovered = SceneDocument.CreateDefault();
            SaveScene(recovered);
            return recovered;
        }
    }

    public IReadOnlyList<string> ListScripts() =>
        Directory.GetFiles(ScriptsPath, "*.cs").Select(Path.GetFileName).Where(x => x is not null).Cast<string>().OrderBy(x => x).ToArray();

    public string SaveScript(string fileName, string source)
    {
        var path = Path.Combine(ScriptsPath, SafeName(Path.GetFileNameWithoutExtension(fileName)) + ".cs");
        File.WriteAllText(path, source);
        return path;
    }

    private void WriteStarterFiles(string project)
    {
        var scripts = Path.Combine(project, "Scripts");
        var native = Path.Combine(project, "Native");
        var script = Path.Combine(scripts, "SpinBehaviour.cs");
        if (!File.Exists(script)) File.WriteAllText(script, StarterScript);
        var cpp = Path.Combine(native, "forge_sample.cpp");
        if (!File.Exists(cpp)) File.WriteAllText(cpp, NativeSample);
        var readme = Path.Combine(native, "README.md");
        if (!File.Exists(readme)) File.WriteAllText(readme, NativeReadme);
    }

    private static string SafeName(string value)
    {
        var invalid = Path.GetInvalidFileNameChars();
        var clean = new string((string.IsNullOrWhiteSpace(value) ? "NewFile" : value.Trim())
            .Select(c => invalid.Contains(c) || c == '/' || c == '\\' ? '_' : c).ToArray());
        return clean.Length > 48 ? clean[..48] : clean;
    }

    public const string StarterScript = """
using ForgeMobile.Engine;

// Starter example. Runtime scripting is a later milestone.
public sealed class SpinBehaviour
{
    public float DegreesPerSecond { get; set; } = 45f;
    public void Update(float deltaTime)
    {
        // TODO: Rotate the attached entity when the script runtime is available.
    }
}
""";

    private const string NativeReadme = """
C++ native modules are built with the Android NDK for a selected ABI (initially arm64-v8a)
and loaded through a narrow, versioned native interface. This prototype stores source files
but does not compile or execute user C++ code on-device yet. Never load arbitrary libraries
from an untrusted project.
""";

    private const string NativeSample = """
#include <cstdint>
extern "C" {
    std::uint32_t forge_module_api_version() { return 1; }
    float forge_demo_saturate(float value) {
        if (value < 0.0f) return 0.0f;
        if (value > 1.0f) return 1.0f;
        return value;
    }
}
""";
}
