using BglReader.Generic;

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

    public ushort MarkingFlags { get; }

    public byte LightsFlags { get; }

    public byte PatternFlags { get; }
    
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