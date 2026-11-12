namespace ForgeMobile.Engine.Core;

public sealed class EntityId
{
    public string Value { get; }
    public EntityId() : this(Guid.NewGuid().ToString("N")) { }
    public EntityId(string value) { Value = string.IsNullOrWhiteSpace(value) ? throw new ArgumentException("ID is required") : value; }
    public override string ToString() => Value;
    public override bool Equals(object? obj) => obj is EntityId other && Value == other.Value;
    public override int GetHashCode() => Value.GetHashCode(StringComparison.Ordinal);
}
