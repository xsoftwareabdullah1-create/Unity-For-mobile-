namespace ForgeMobile.Engine.Core;

public sealed class Guard
{

    public static string NotBlank(string? value, string name) => string.IsNullOrWhiteSpace(value) ? throw new ArgumentException($"{name} is required", name) : value.Trim();
    public static float Finite(float value, string name) => float.IsFinite(value) ? value : throw new ArgumentOutOfRangeException(name);
}
