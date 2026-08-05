// ReSharper disable UnusedMember.Global
namespace BglReader.Attributes.BinaryAttributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
public sealed class BinarySerializableAttribute : Attribute;

[AttributeUsage(AttributeTargets.Property)]
public class BinaryAttribute(int order) : Attribute
{
    public int Order { get; } = order;
}

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
public sealed class BinaryReaderAttribute(Type readerType) : Attribute
{
    public Type ReaderType { get; } = readerType;
}

[AttributeUsage(AttributeTargets.Property)]
public sealed class BinaryCollectionAttribute(string countProperty) : Attribute
{
    public string CountProperty { get; } = countProperty;
}

[AttributeUsage(AttributeTargets.Property)]
public sealed class BinaryPolymorphicCollectionAttribute(Type factoryType, Type idType) : Attribute
{
    public Type FactoryType { get; } = factoryType;
    
    public Type IdType { get; } = idType;
}

[AttributeUsage(AttributeTargets.Property)]
public sealed class BinaryConditionAttribute<TValue>(string property, BinaryComparison comparison, TValue value)
    : Attribute
{
    public string Property { get; } = property;
    
    public BinaryComparison Comparison { get; } = comparison;
    
    public TValue Value { get; } = value;
}

public enum BinaryComparison
{
    Equal = 0,
    NotEqual = 1,

    LessThan = 2,
    LessThanOrEqual = 3,

    GreaterThan = 4,
    GreaterThanOrEqual = 5,
}