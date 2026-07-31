using BglReader.Airport;
using BglReader.Airport.Subsections.Types;
using BglReader.Types;
using BglReader.ValueObjects.BitFields;

namespace BglReader;

public interface IBinaryValueReader<out T>
{
    T Read(ushort id, BglBinaryReader reader);
}

public sealed class ApproachFixReader : IBinaryValueReader<(FixType, IcaoIdentifier)>
{
    public (FixType, IcaoIdentifier) Read(ushort id, BglBinaryReader reader) => (AirportSubsectionDataType)id switch
    {
        AirportSubsectionDataType.Approach => PackedRead(reader),
        AirportSubsectionDataType.ApproachP3DV6 => V6Read(reader),
        _ => throw new ArgumentOutOfRangeException(nameof(id), id, null)
    };

    private (FixType, IcaoIdentifier) V6Read(BglBinaryReader reader) =>
        ((FixType)reader.ReadUInt32(), new IcaoIdentifier(reader.ReadUInt32()));

    private (FixType, IcaoIdentifier) PackedRead(BglBinaryReader reader)
    {
        var fixFlags = new FixFlags(reader.ReadUInt32());
        return (fixFlags.Type, fixFlags.Identifier);
    }
}