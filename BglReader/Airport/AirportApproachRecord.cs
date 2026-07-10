using BglReader.Generic;

namespace BglReader.Airport;

public class AirportApproachRecord : BglRecord
{
    public AirportApproachRecord(
        BinaryReader reader) : base(reader)
    {
        Suffix = reader.ReadByte();
        RunwayNumber = reader.ReadByte();
        var flags = reader.ReadByte();
        ApproachType = (ApproachType)(flags & 0xF);

        RunwayDesignator = (flags >> 4) & 0x7;
        GpsOverlay = (flags & 0x80) == 0x80;

        NumberOfTransitions = reader.ReadByte();
        NumberOfApproachLegs = reader.ReadByte();
        NumberOfMissedApproachLegs = reader.ReadByte();
        
        var fixFlags = reader.ReadUInt32();
        FixType = (FixType)(fixFlags & 0xF);
        FixIdentifier = IcaoIdentifier.Parse((fixFlags >> 5) & 0x7FFFFFF);

        var regionFlags = reader.ReadUInt32();
        FixRegion = IcaoIdentifier.Parse(regionFlags & 0x7FF);
        FixAirportIdentifier = IcaoIdentifier.Parse((regionFlags >> 11) & 0x1FFFFF);
        
        Altitude = reader.ReadSingle();
        Heading = reader.ReadSingle();
        MissedAltitude = reader.ReadSingle();

        MapSubRecords(reader);
    }

    public byte Suffix { get; }

    public byte RunwayNumber { get; }
    
    public ApproachType ApproachType { get; }
    
    public int RunwayDesignator { get; }
    
    public bool GpsOverlay { get; }

    public byte NumberOfTransitions { get; }

    public byte NumberOfApproachLegs { get; }

    public byte NumberOfMissedApproachLegs { get; }
    
    public FixType FixType { get; }
    
    public IcaoIdentifier FixIdentifier { get; }

    public IcaoIdentifier FixRegion { get; }
    
    public IcaoIdentifier FixAirportIdentifier { get; }

    public float Altitude { get; }

    public float Heading { get; }

    public float MissedAltitude { get; }

    public ICollection<BglRecord> SubRecords { get; } = new List<BglRecord>();

    private void MapSubRecords(BinaryReader reader)
    {
        var iterationStartPos = GetRecordStartPosition();
        while (reader.BaseStream.Position < iterationStartPos + Size)
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