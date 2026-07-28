using BglReader.Airport;
using BglReader.Generic;
using BglReader.Types;
using BglReader.ValueObjects.BitFields;

namespace BglReader.Navigation;

public class BoundaryRecord : BglRecord
{
    public BoundaryRecord(ushort id, BglBinaryReader reader) : base(id, reader)
    {
        Type = reader.ReadByte();

        Flags = new BoundaryFlags(reader.ReadByte());

        MinimumCoordinates = reader.ReadCoordinates();
        MaximumCoordinates = reader.ReadCoordinates();

        Name = new NameRecord((ushort)AirportSubsectionDataType.Name, reader);
    }

    public byte Type { get; }

    public BoundaryFlags Flags { get; }

    public Coordinate MinimumCoordinates { get; }

    public Coordinate MaximumCoordinates { get; }

    public NameRecord Name { get; }
}