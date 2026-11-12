namespace ForgeMobile.Engine.Audio;

public sealed class AudioMixer
{
    public Dictionary<string,float> Groups { get; } = new(){{"Master",1},{"Music",1},{"SFX",1}};
    public void SetVolume(string group,float value)=>Groups[group]=Math.Clamp(value,0,1);
    public float GetVolume(string group)=>Groups.GetValueOrDefault(group,1);
}
