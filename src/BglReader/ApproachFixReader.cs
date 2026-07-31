using BglReader.Airport;
using BglReader.Airport.Subsections.Apron;
using BglReader.Airport.Subsections.Types;
using BglReader.Types;
using BglReader.ValueObjects.BitFields;

namespace BglReader;

public sealed class ApronTriangleReader : IBinaryValueReader<ApronTriangle>
{
    public ApronTriangle Read(BglBinaryReader reader) => new(reader.ReadUInt16(), reader.ReadUInt16(), reader.ReadUInt16());
}

public sealed class GuidValueReader : IBinaryValueReader<Guid>
{
    public Guid Read(BglBinaryReader reader) => new(reader.ReadBytes(16));
}

public sealed class ElevationBinaryValueReader : IBinaryValueReader<Elevation>
{
    public Elevation Read(BglBinaryReader reader) => new(reader.ReadInt32() / 1000f);
}

public sealed class IcaoIdentifierReader : IBinaryValueReader<IcaoIdentifier>
{
    public IcaoIdentifier Read(BglBinaryReader reader) => new(reader.ReadUInt32());
}

public sealed class ShiftedIcaoIdentifierReader : IBinaryValueReader<IcaoIdentifier>
{
    public IcaoIdentifier Read(BglBinaryReader reader) => new(reader.ReadUInt32() >> 5);
}

public sealed class ApproachFixReader : IBinaryRecordReader<(FixType, IcaoIdentifier)>
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

public sealed class TwoDimensionalCoordinateReader
    : IBinaryValueReader<Coordinate>
{
    public Coordinate Read(BglBinaryReader reader) =>
        reader.ReadCoordinates(hasElevation: false);
}

public sealed class ThreeDimensionalCoordinateReader
    : IBinaryValueReader<Coordinate>
{
    public Coordinate Read(BglBinaryReader reader) =>
        reader.ReadCoordinates(hasElevation: true);
}