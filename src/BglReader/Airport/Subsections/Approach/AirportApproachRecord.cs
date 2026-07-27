using BglReader.Airport.Subsections.Types;
using BglReader.Generic;
using BglReader.ValueObjects;

namespace BglReader.Airport.Subsections.Approach;

public class AirportApproachRecord : BglRecord
{
    public AirportApproachRecord(
        ushort id,
        BglBinaryReader reader) : base(id, reader)
    {
        Suffix = reader.ReadByte();
        RunwayNumber = reader.ReadByte();
        ApproachFlags = new ApproachFlags(reader.ReadByte());

        NumberOfTransitions = reader.ReadByte();
        NumberOfApproachLegs = reader.ReadByte();
        NumberOfMissedApproachLegs = reader.ReadByte();

        (FixType, FixIdentifier) = (AirportSubsectionDataType)Id == AirportSubsectionDataType.ApproachP3DV6
            ? ReadV6FixFlags(reader)
            : ReadPackedFixFlags(reader);

        FixRegionFlags = new RegionIdentifierFlags(reader.ReadUInt32());
        
        Altitude = reader.ReadSingle();
        Heading = reader.ReadSingle();
        MissedAltitude = reader.ReadSingle();

        MapSubRecords(reader);
    }

    public byte Suffix { get; }

    public byte RunwayNumber { get; }
    
    public ApproachFlags ApproachFlags { get; }

    public byte NumberOfTransitions { get; }

    public byte NumberOfApproachLegs { get; }

    public byte NumberOfMissedApproachLegs { get; }
    
    public FixType FixType { get; }
    
    public IcaoIdentifier FixIdentifier { get; }

    public RegionIdentifierFlags FixRegionFlags { get; }

    public float Altitude { get; }

    public float Heading { get; }

    public float MissedAltitude { get; }

    public ICollection<BglRecord> SubRecords { get; } = new List<BglRecord>();

    private void MapSubRecords(BglBinaryReader reader)
    {
        while (reader.Position < EndPosition)
        {
            var id = reader.ReadUInt16();

            var record = BglRecordFactory.Create((AirportApproachDataType)id, reader);

            if (record is not null)
            {
                SubRecords.Add(record);
            }
        }
    }
    
    private static (FixType FixType, IcaoIdentifier IcaoIdentifier) ReadV6FixFlags(BglBinaryReader reader) => ((FixType)reader.ReadUInt32(), new IcaoIdentifier(reader.ReadUInt32()));

    private static (FixType FixType, IcaoIdentifier IcaoIdentifier) ReadPackedFixFlags(BglBinaryReader reader)
    {
        var fixFlags = new FixFlags(reader.ReadUInt32());
        return (fixFlags.Type, fixFlags.Identifier);
    }
}