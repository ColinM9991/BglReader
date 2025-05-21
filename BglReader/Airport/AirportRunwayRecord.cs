namespace BglReader.Airport;

// TODO FLags
public class AirportRunwayRecord : BglRecord
{
    public AirportRunwayRecord(
        BinaryReader reader) : base(reader)
    {
        SurfaceType = (SurfaceType)reader.ReadUInt16();
        RunwayNumber = reader.ReadByte();
        Designator = (RunwayDesignator)reader.ReadByte();
        SecondaryRunwayNumber = reader.ReadByte();
        SecondaryRunwayDesignator = reader.ReadByte();
        PrimaryIlsIdentifier = IcaoIdentifier.Parse(reader.ReadUInt32());
        SecondaryIlsIdentifier = IcaoIdentifier.Parse(reader.ReadUInt32());
        Coordinates = new Coordinate(reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32());
        Length = reader.ReadSingle();
        Width = reader.ReadSingle();
        Heading = reader.ReadSingle();
        PatternAltitude = reader.ReadSingle();
        MarkingFlags = reader.ReadUInt16();
        LightsFlags = reader.ReadByte();
        PatternFlags = reader.ReadByte();

        _ = reader.ReadBytes(16);

        MapSubrecords(reader);
    }

    public SurfaceType SurfaceType { get; set; }

    public byte RunwayNumber { get; set; }

    public RunwayDesignator Designator { get; set; }

    public byte SecondaryRunwayNumber { get; set; }

    public byte SecondaryRunwayDesignator { get; set; }

    public IcaoIdentifier PrimaryIlsIdentifier { get; set; }

    public IcaoIdentifier SecondaryIlsIdentifier { get; set; }

    public Coordinate Coordinates { get; set; }

    public float Length { get; set; }

    public float Width { get; set; }

    public float Heading { get; set; }

    public float PatternAltitude { get; set; }

    public ushort MarkingFlags { get; set; }

    public byte LightsFlags { get; set; }

    public byte PatternFlags { get; set; }

    public ICollection<BglRecord> Subrecords { get; set; } = new List<BglRecord>();

    private void MapSubrecords(BinaryReader reader)
    {
        var iterationStartPos = GetRecordStreamPosition();
        var totalSize = iterationStartPos + Size;
        while (reader.BaseStream.Position < totalSize)
        {
            var id = reader.ReadUInt16();

            BglRecord? record = (AirportRecordDataType)id switch
            {
                AirportRecordDataType.OffsetPrimary or AirportRecordDataType.OffsetSecondary => new
                    AirportSubReportBaseRecord(reader, AirportSubReportBaseRecord.SubReportBaseType.OffsetThreshold),
                AirportRecordDataType.BlastPadPrimary or AirportRecordDataType.BlastPadSecondary => new
                    AirportSubReportBaseRecord(reader, AirportSubReportBaseRecord.SubReportBaseType.BlastPad),
                AirportRecordDataType.OverrunPrimary or AirportRecordDataType.OverrunSecondary => new
                    AirportSubReportBaseRecord(reader, AirportSubReportBaseRecord.SubReportBaseType.Overrun),
                AirportRecordDataType.VasiLeftPrimary or AirportRecordDataType.VasiLeftSecondary
                    or AirportRecordDataType.VasiRightPrimary
                    or AirportRecordDataType.VasiRightSecondary => new AirportVasiSubRecord(reader),
                AirportRecordDataType.ApproachLightsPrimary or AirportRecordDataType.ApproachLightsSecondary =>
                    new AirportApproachLightsSubRecord(reader),
                AirportRecordDataType.MarkingBias => new AirportMarkingBiasSubReportRecord(reader),
                _ => null,
            };

            if (record is not null)
            {
                Subrecords.Add(record);
            }
        }
    }

    public enum RunwayDesignator : byte
    {
        None = 0,
        Left = 1,
        Right = 2,
        Center = 3,
        Water = 4,
        A = 5,
        B = 6,
    }
}