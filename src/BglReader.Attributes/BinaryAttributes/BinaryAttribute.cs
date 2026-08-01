namespace BglReader.Attributes.BinaryAttributes;

[AttributeUsage(AttributeTargets.Class)]
public sealed class BinarySerializableAttribute : Attribute;

[AttributeUsage(AttributeTargets.Property)]
public class BinaryAttribute(int index) : Attribute;

[AttributeUsage(AttributeTargets.Property)]
public class BinaryDiscardAttribute(int count) : Attribute;

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