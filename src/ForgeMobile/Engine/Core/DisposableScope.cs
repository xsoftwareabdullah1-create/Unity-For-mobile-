namespace ForgeMobile.Engine.Core;

public sealed class DisposableScope
{
    private readonly List<IDisposable> _items = new();
    public T Add<T>(T item) where T : IDisposable { _items.Add(item); return item; }
    public void Dispose() { for (var i = _items.Count - 1; i >= 0; i--) _items[i].Dispose(); _items.Clear(); }
}
