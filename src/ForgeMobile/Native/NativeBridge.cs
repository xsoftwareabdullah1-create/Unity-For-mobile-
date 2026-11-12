namespace ForgeMobile.Engine.Platform;

/// <summary>JNI bridge contract. Native library loading is opt-in until the NDK artifact is packaged.</summary>
public static class NativeBridge
{
    public static bool IsAvailable { get; private set; }
    public static string Status { get; private set; } = "Native module not loaded";
    public static void MarkAvailable() { IsAvailable = true; Status = "Native module loaded"; }
    public static void MarkUnavailable(string reason) { IsAvailable = false; Status = reason; }
}
