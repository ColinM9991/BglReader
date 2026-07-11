using BglReader.Attributes;
using BglReader.Generic;

namespace BglReader.Airport;

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
        MarkingFlags = new RunwayMarkingFlags(reader.ReadUInt16());
        LightsFlags = new RunwayLightFlags(reader.ReadByte());
        PatternFlags = new RunwayPatternFlags(reader.ReadByte());

        if ((AirportSubsectionDataType)Id is AirportSubsectionDataType.RunwayP3DV4)
            Material = new Guid(reader.ReadBytes(16));

        MapSubRecords(reader);
    }

    public SurfaceType SurfaceType { get; }

    public byte RunwayNumber { get; }

    public RunwayDesignator Designator { get; }

    public byte SecondaryRunwayNumber { get; }

    public byte SecondaryRunwayDesignator { get; }

    public IcaoIdentifier PrimaryIlsIdentifier { get; }

    public IcaoIdentifier SecondaryIlsIdentifier { get; }

    public Coordinate Coordinates { get; }

    public float Length { get; }

    public float Width { get; }

    public float Heading { get; }

    public float PatternAltitude { get; }

    public RunwayMarkingFlags MarkingFlags { get; }

    public RunwayLightFlags LightsFlags { get; }

    public RunwayPatternFlags PatternFlags { get; }

    public Guid? Material { get; }

    public ICollection<BglRecord> SubRecords { get; } = new List<BglRecord>();

    private void MapSubRecords(BinaryReader reader)
    {
        var endPosition = GetRecordEndPosition();
        while (reader.BaseStream.Position < endPosition)
        {
            var id = reader.ReadUInt16();

            var record = BglRecordFactory.Create((AirportRecordDataType)id, reader);

            if (record is not null)
            {
                SubRecords.Add(record);
            }
        }
    }
}

[BitField(typeof(ushort))]
public partial class RunwayMarkingFlags
{
    [Bits(0)] public partial bool Edges { get; }

    [Bits(1)] public partial bool Threshold { get; }

    [Bits(2)] public partial bool FixedDistance { get; }

    [Bits(3)] public partial bool Touchdown { get; }

    [Bits(4)] public partial bool Dashes { get; }

    [Bits(5)] public partial bool Ident { get; }

    [Bits(6)] public partial bool Precision { get; }

    [Bits(7)] public partial bool EdgePavement { get; }

    [Bits(8)] public partial bool SingleEnd { get; }

    [Bits(9)] public partial bool PrimaryClosed { get; }

    [Bits(10)] public partial bool SecondaryClosed { get; }

    [Bits(11)] public partial bool PrimaryStol { get; }

    [Bits(12)] public partial bool SecondaryStol { get; }

    [Bits(13)] public partial bool AlternateThreshold { get; }

    [Bits(14)] public partial bool AlternateFixedDistance { get; }

    [Bits(15)] public partial bool AlternateTouchdown { get; }
}

public enum RunwayLightIntensity : byte
{
    None = 0,
    Low = 1,
    Medium = 2,
    High = 3
}

[BitField(typeof(byte))]
public partial class RunwayLightFlags
{
    [Bits(0, 2)] public partial RunwayLightIntensity Edge { get; }

    [Bits(2, 2)] public partial RunwayLightIntensity Center { get; }

    [Bits(4)] public partial bool CenterRed { get; }

    [Bits(5)] public partial bool AlternatePrecision { get; }

    [Bits(6)] public partial bool LeadingZeroIdent { get; }

    [Bits(7)] public partial bool NoThresholdEndArrows { get; }
}

public enum RunwayPatternDirection : byte
{
    Left = 0,
    Right = 1
}

[BitField(typeof(byte))]
public partial class RunwayPatternFlags
{
    [Bits(0)] public partial bool PrimaryTakeoff { get; }

    [Bits(1)] public partial bool PrimaryLanding { get; }

    [Bits(2)] public partial RunwayPatternDirection PrimaryPattern { get; }

    [Bits(3)] public partial bool SecondaryTakeoff { get; }

    [Bits(4)] public partial bool SecondaryLanding { get; }

    [Bits(5)] public partial RunwayPatternDirection SecondaryPattern { get; }

    [Bits(6)] public partial bool PrimaryMarkingBias { get; }

    [Bits(7)] public partial bool SecondaryMarkingBias { get; }
}