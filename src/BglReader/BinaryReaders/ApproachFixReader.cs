using BglReader.Airport;
using BglReader.Airport.Subsections.Types;
using BglReader.Types;
using BglReader.ValueObjects.BitFields;

namespace BglReader.BinaryReaders;

public sealed class ApproachFixReader : IBinaryRecordReader<(FixType, IcaoIdentifier)>
{
    public (FixType, IcaoIdentifier) Read(ushort id, BglBinaryReader reader) => (AirportSubsectionDataType)id switch
    {
        AirportSubsectionDataType.Approach => PackedRead(reader),
        AirportSubsectionDataType.ApproachP3DV6 => V6Read(reader),
        _ => throw new ArgumentOutOfRangeException(nameof(id), id, null)
    };

    private static (FixType, IcaoIdentifier) V6Read(BglBinaryReader reader) =>
        ((FixType)reader.ReadUInt32(), new IcaoIdentifier(reader.ReadUInt32()));

    private static (FixType, IcaoIdentifier) PackedRead(BglBinaryReader reader)
    {
        var fixFlags = new FixFlags(reader.ReadUInt32());
        return (fixFlags.Type, fixFlags.Identifier);
    }
}