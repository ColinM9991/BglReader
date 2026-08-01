using BglReader.Types;
using BglReader.ValueObjects.BitFields;

namespace BglReader.Airport.Subsections.Approach;

[BinarySerializable]
public partial class TransitionDmeRecord
{
    [Binary(0)]
    [BinaryReader(typeof(ShiftedIcaoIdentifierReader))]
    public IcaoIdentifier? DmeIdent { get; }

    [Binary(1)]
    public RegionIdentifierFlags? DmeRegionFlags { get; }

    [Binary(2)]
    public uint Radial { get; }

    [Binary(3)]
    public float Distance { get; }
}