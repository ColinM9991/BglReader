namespace BglReader.Airport;

public class AirportApproachRecord : BglRecord
{
    public AirportApproachRecord(
        BinaryReader reader) : base(reader)
    {
        Suffix = reader.ReadByte();
        RunwayNumber = reader.ReadByte();
        Flags = reader.ReadByte();
        NumberOfTransitions = reader.ReadByte();
        NumberOfApproachLegs = reader.ReadByte();
        NumberOfMissedApproachLegs = reader.ReadByte();
        FixIdentFlags = reader.ReadUInt32();
        IcaoFlags = reader.ReadUInt32();
        Altitude = reader.ReadSingle();
        Heading = reader.ReadSingle();
        MissedAltitude = reader.ReadSingle();

        MapSubRecords(reader);
    }

    public byte Suffix { get; }

    public byte RunwayNumber { get; }

    public byte Flags { get; } // TODO Flags

    public byte NumberOfTransitions { get; }

    public byte NumberOfApproachLegs { get; }

    public byte NumberOfMissedApproachLegs { get; }

    public uint FixIdentFlags { get; } // TODO Flags

    public uint IcaoFlags { get; } // TODO Flags

    public float Altitude { get; }

    public float Heading { get; set; }

    public float MissedAltitude { get; }

    public ICollection<BglRecord> SubRecords { get; } = new List<BglRecord>();

    private void MapSubRecords(BinaryReader reader)
    {
        var iterationStartPos = GetRecordStreamPosition();
        while (reader.BaseStream.Position < iterationStartPos + Size)
        {
            var id = reader.ReadUInt16();

            BglRecord? record = (AirportApproachDataType)id switch
            {
                AirportApproachDataType.ApproachLegs => new AirportLegBaseRecord(reader),
                AirportApproachDataType.MissedApproachLegs => new AirportLegBaseRecord(reader),
                AirportApproachDataType.Transition => new AirportTransitionRecord(reader),
                _ => null,
            };

            if (record is not null)
            {
                SubRecords.Add(record);
            }
        }
    }
}

public class AirportLegBaseRecord : BglRecord
{
    public AirportLegBaseRecord(
        BinaryReader reader, bool rewindStream = true) : base(reader, rewindStream)
    {
        NumberOfLegs = reader.ReadUInt16();

        MapLegs(reader);
    }

    public ushort NumberOfLegs { get; }

    public ICollection<ApproachLeg> Legs { get; } = new List<ApproachLeg>();

    private void MapLegs(BinaryReader reader)
    {
        if (NumberOfLegs == 0) return;

        for (var i = 0; i < NumberOfLegs; i++)
        {
            Legs.Add(new ApproachLeg(reader));
        }
    }
}

public class AirportTransitionRecord : BglRecord
{
    public AirportTransitionRecord(BinaryReader reader) : base(reader)
    {
        Type = reader.ReadByte();
        NumberOfTransitionLegs = reader.ReadByte();
        FixFlags = reader.ReadUInt32();
        RegionFlags = reader.ReadUInt32();  
        Altitude = reader.ReadSingle();

        if (Type == 0x2)
        {
            DmeIdent = reader.ReadUInt32();
            DmeRegionFlags = reader.ReadUInt32();
            Radial = reader.ReadUInt32();
            Distance = reader.ReadSingle();
        }
        
        LegRecord = new AirportLegBaseRecord(reader, false);
    }

    public byte Type { get; }
    
    public byte NumberOfTransitionLegs { get; }
    
    public uint FixFlags { get; }
    
    public uint RegionFlags { get; }
    
    public float Altitude { get; }
    
    public uint DmeIdent { get; }
    
    public uint DmeRegionFlags { get; }
    
    public uint Radial { get; }
    
    public float Distance { get; }
    
    public AirportLegBaseRecord LegRecord { get; set; }
}

public readonly struct ApproachLeg
{
    public ApproachLeg(
        BinaryReader reader)
    {
        Id = reader.ReadByte();
        AltitudeDescriptor = reader.ReadByte();
        Flags = reader.ReadUInt16();
        FixFlags = reader.ReadUInt32();
        IcaoFlags = reader.ReadUInt32();
        RecommendedIdentFlags = reader.ReadUInt32();
        RecommendedAirportFlags = reader.ReadUInt32();
        Theta = reader.ReadSingle();
        Rho = reader.ReadSingle();
        Course = reader.ReadSingle();
        DistanceTime = reader.ReadSingle();
        Altitude1 = reader.ReadSingle();
        Altitude2 = reader.ReadSingle();
    }

    public byte Id { get; }

    public byte AltitudeDescriptor { get; }

    public ushort Flags { get; }

    public uint FixFlags { get; }

    public uint IcaoFlags { get; }

    public uint RecommendedIdentFlags { get; }

    public uint RecommendedAirportFlags { get; }

    public float Theta { get; }

    public float Rho { get; }

    public float Course { get; }

    public float DistanceTime { get; }

    public float Altitude1 { get; }

    public float Altitude2 { get; }
}