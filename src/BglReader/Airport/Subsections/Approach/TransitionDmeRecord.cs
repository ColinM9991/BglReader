using BglReader.Types;
using BglReader.ValueObjects.BitFields;

namespace BglReader.Airport.Subsections.Approach;

[BinarySerializable]
public partial class TransitionDmeRecord
{
    [Binary(1)]
    [BinaryReader(typeof(ShiftedIcaoIdentifierReader))]
    public IcaoIdentifier? DmeIdent { get; }

    [Binary(2)]
    public RegionIdentifierFlags? DmeRegionFlags { get; }

    [Binary(3)]
    public uint Radial { get; }

    [Binary(4)]
    public float Distance { get; }
}