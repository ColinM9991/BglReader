using BglReader.Generic;
using BglReader.ValueObjects;

namespace BglReader.Airport;

public class AirportApproachRecord : BglRecord
{
    public AirportApproachRecord(
        BglBinaryReader reader) : base(reader)
    {
        Suffix = reader.ReadByte();
        RunwayNumber = reader.ReadByte();
        ApproachFlags = new ApproachFlags(reader.ReadByte());

        NumberOfTransitions = reader.ReadByte();
        NumberOfApproachLegs = reader.ReadByte();
        NumberOfMissedApproachLegs = reader.ReadByte();
        
        FixFlags = new FixFlags(reader.ReadUInt32());

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
    
    public FixFlags FixFlags { get; }

    public RegionIdentifierFlags FixRegionFlags { get; }

    public float Altitude { get; }

    public float Heading { get; }

    public float MissedAltitude { get; }

    public ICollection<BglRecord> SubRecords { get; } = new List<BglRecord>();

    private void MapSubRecords(BglBinaryReader reader)
    {
        var iterationStartPos = GetRecordStartPosition();
        while (reader.Position < iterationStartPos + Size)
        {
            var id = reader.ReadUInt16();

            var record = BglRecordFactory.Create((AirportApproachDataType)id, reader);

            if (record is not null)
            {
                SubRecords.Add(record);
            }
        }
    }
}