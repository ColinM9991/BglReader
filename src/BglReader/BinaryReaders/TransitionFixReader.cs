using BglReader.Airport.Subsections.Approach;
using BglReader.Airport.Subsections.Types;
using BglReader.Types;

namespace BglReader.BinaryReaders;

public sealed class TransitionFixReader : FixReaderBase, IBinaryRecordReader<(FixType, IcaoIdentifier)>
{
    public static (FixType, IcaoIdentifier) Read(BglRecordContext context, BglBinaryReader reader) =>
        (AirportApproachDataType)context.RecordId switch
        {
            AirportApproachDataType.Transition => PackedRead(reader),
            AirportApproachDataType.TransitionV6 => V6Read(reader),
            _ => throw new ArgumentOutOfRangeException(nameof(context.RecordId), context, null)
        };
}