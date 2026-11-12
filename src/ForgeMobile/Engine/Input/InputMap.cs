namespace ForgeMobile.Engine.Input;

public sealed class InputMap
{
    public List<InputBinding> Bindings { get; } = new();
    public IEnumerable<InputBinding> ForAction(string action)=>Bindings.Where(x=>x.Action.Equals(action,StringComparison.OrdinalIgnoreCase));
    public void Bind(string action,string device,string control)=>Bindings.Add(new(){Action=action,Device=device,Control=control});
}
