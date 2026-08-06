
namespace BglReader.Airport.Subsections.Types;

[BitField(typeof(uint))]
public partial class DeleteFrequency
{
    [Bits(28, 2)] // TODO validate higher order bit
    public partial ComType Type { get; }

    [Bits(0, 28)]
    public partial Frequency Frequency { get; }
}