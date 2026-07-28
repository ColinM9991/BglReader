namespace BglReader.Attributes.BinaryAttributes;

[AttributeUsage(AttributeTargets.Class)]
public sealed class BinarySerializableAttribute : Attribute;

[AttributeUsage(AttributeTargets.Property)]
public class BinaryAttribute(int index) : Attribute
{
    public int Index { get; } = index;
}

[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
public sealed class BinaryReaderAttribute(Type readerType) : Attribute
{
    public Type Reader { get; } = readerType;
}

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
public sealed class BinaryRecordVersionAttribute(ushort version) : Attribute
{
    public ushort Version { get; } = version;
}

[AttributeUsage(AttributeTargets.Property)]
public sealed class BinaryCollectionAttribute(string countProperty) : Attribute
{
    public string CountProperty { get; } = countProperty;
}

[AttributeUsage(AttributeTargets.Property)]
public sealed class BinaryConditionAttribute(string countProperty) : Attribute
{
    public string CountProperty { get; } = countProperty;
}