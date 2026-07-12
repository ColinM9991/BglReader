using BglReader.Generic;
using BglReader.ValueObjects;

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
        PrimaryIlsIdentifier = new IcaoIdentifier(reader.ReadUInt32());
        SecondaryIlsIdentifier = new IcaoIdentifier(reader.ReadUInt32());
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