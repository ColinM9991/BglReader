namespace BglReader.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public sealed class BitFieldAttribute(Type type) : Attribute
{
    public Type Type { get; } = type;
}