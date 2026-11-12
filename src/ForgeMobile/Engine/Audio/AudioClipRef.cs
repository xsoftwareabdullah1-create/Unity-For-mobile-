namespace ForgeMobile.Engine.Audio;

public sealed class AudioClipRef
{
    public string AssetId { get; set; } = "";
    public string Name { get; set; } = "Audio Clip";
    public float Duration { get; set; }
    public int SampleRate { get; set; } = 44100;

}
