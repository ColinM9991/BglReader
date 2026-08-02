using BglReader.Airport;
using BglReader.Airport.Subsections.Types;
using BglReader.Types;

namespace BglReader.BinaryReaders;

public sealed class ApproachFixReader  : FixReaderBase, IBinaryRecordReader<(FixType, IcaoIdentifier)>
{
    public (FixType, IcaoIdentifier) Read(ushort id, BglBinaryReader reader) =>
        (AirportSubsectionDataType)id switch
        {
            AirportSubsectionDataType.Approach => PackedRead(reader),
            AirportSubsectionDataType.ApproachP3DV6 => V6Read(reader),
            _ => throw new ArgumentOutOfRangeException(nameof(id), id, null)
        };
}