using BglReader.Airport;
using BglReader.Airport.Subsections.Types;
using BglReader.Types;

namespace BglReader.BinaryReaders;

public sealed class ApproachFixReader : FixReaderBase, IBinaryRecordReader<(FixType, IcaoIdentifier)>
{
    public static (FixType, IcaoIdentifier) Read(BglRecordContext context, BglBinaryReader reader) =>
        (AirportSubsectionDataType)context.RecordId switch
        {
            AirportSubsectionDataType.Approach => PackedRead(reader),
            AirportSubsectionDataType.ApproachP3DV6 => V6Read(reader),
            _ => throw new ArgumentOutOfRangeException(nameof(context), context, null)
        };
}