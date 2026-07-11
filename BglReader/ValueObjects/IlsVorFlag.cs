using BglReader.Attributes;

namespace BglReader.ValueObjects;

[BitField(typeof(byte))]
public partial class IlsVorFlag
{
    [Bits(0)]
    public partial bool IsNotDmeOnly { get; }
    
    [Bits(2)]
    public partial bool IsBackCourse { get; }
    
    [Bits(3)]
    public partial bool HasGlideslope { get; }
    
    [Bits(4)]
    public partial bool IsDmePresent { get; }
    
    [Bits(5)]
    public partial bool NavTrue { get; }
}