using BglReader.Airport.Subsections.Approach;
using BglReader.Airport.Subsections.Types;
using BglReader.Types;

namespace BglReader.BinaryReaders;

public sealed class TransitionFixReader : FixReaderBase, IBinaryRecordReader<(FixType, IcaoIdentifier)>
{
    public (FixType, IcaoIdentifier) Read(ushort id, BglBinaryReader reader) =>
        (AirportApproachDataType)id switch
        {
            AirportApproachDataType.Transition => PackedRead(reader),
            AirportApproachDataType.TransitionV6 => V6Read(reader),
            _ => throw new ArgumentOutOfRangeException(nameof(id), id, null)
        };
}