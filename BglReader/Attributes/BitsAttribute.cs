namespace BglReader.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public sealed class BitsAttribute(
    int offset,
    int length) : Attribute
{
    public int Offset { get; } = offset;

    public int Length { get; } = length;
}