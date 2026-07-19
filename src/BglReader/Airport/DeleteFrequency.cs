using BglReader.Attributes;

namespace BglReader.Airport;

[BitField(typeof(uint))]
public partial class DeleteFrequency
{
    [Bits(28, 4)]
    public partial ComType Type { get; }

    [Bits(0, 28)]
    public partial Frequency Frequency { get; }
}