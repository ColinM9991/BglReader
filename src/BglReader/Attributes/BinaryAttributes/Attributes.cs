namespace BglReader.Attributes.BinaryAttributes;

[AttributeUsage(AttributeTargets.Class)]
public sealed class BinarySerializableAttribute : Attribute;

[AttributeUsage(AttributeTargets.Property)]
public class BinaryAttribute(int Order) : Attribute;

public abstract class BinaryByteCountAttribute(object specification) : Attribute
{
    public object Specification { get; } = specification;
}

[AttributeUsage(AttributeTargets.Property)]
public sealed class BinaryConsumeAttribute : BinaryByteCountAttribute
{
    public BinaryConsumeAttribute(int specification)
        : base(specification)
    {
    }

    public BinaryConsumeAttribute(string specification)
        : base(specification)
    {
    }
}

[AttributeUsage(AttributeTargets.Property)]
public sealed class BinaryStringAttribute : BinaryByteCountAttribute
{
    public BinaryStringAttribute(int specification)
        : base(specification)
    {
    }

    public BinaryStringAttribute(string specification)
        : base(specification)
    {
    }
}

[AttributeUsage(AttributeTargets.Property)]
public sealed class BinaryNullTerminatedStringAttribute(int alignment)
    : Attribute
{
    public int Alignment { get; } = alignment;
}

[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
public sealed class BinaryReaderAttribute(Type readerType) : Attribute;

[AttributeUsage(AttributeTargets.Property)]
public sealed class BinaryCollectionAttribute(string countProperty) : Attribute;

[AttributeUsage(AttributeTargets.Property)]
public sealed class BinaryPolymorphicCollectionAttribute(Type factoryType, Type idType) : Attribute;

[AttributeUsage(AttributeTargets.Property)]
public sealed class BinaryConditionAttribute<TValue>(string property, BinaryComparison comparison, TValue value)
    : Attribute;

public enum BinaryComparison
{
    Equal = 0,
    NotEqual = 1,

    LessThan = 2,
    LessThanOrEqual = 3,

    GreaterThan = 4,
    GreaterThanOrEqual = 5,
}