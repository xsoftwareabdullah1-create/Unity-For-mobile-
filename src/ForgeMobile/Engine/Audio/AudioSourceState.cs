namespace ForgeMobile.Engine.Audio;

public sealed class AudioSourceState
{
    public string ClipId { get; set; } = "";
    public float Volume { get; set; } = 1;
    public float Pitch { get; set; } = 1;
    public bool Loop { get; set; }
    public bool PlayOnAwake { get; set; }
    public void Clamp(){Volume=Math.Clamp(Volume,0,1);Pitch=Math.Clamp(Pitch,.1f,3); }
}
