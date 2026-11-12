namespace ForgeMobile.Engine.Core;

public sealed class CommandQueue
{
    private readonly Queue<Action> _commands = new();
    public int Count => _commands.Count;
    public void Enqueue(Action command) => _commands.Enqueue(command);
    public void ExecuteAll(int max = 128) { var n = 0; while (_commands.Count > 0 && n++ < max) _commands.Dequeue()(); }
}
