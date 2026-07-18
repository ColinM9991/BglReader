using BglReader.Generic;

namespace BglReader.Airport;

public class AirportRecord : BglRecord
{
    public AirportRecord(
        BglBinaryReader reader) : base(reader, false)
    {
        _ = reader.ReadBytes(6); // Number of Runways, Com, Starts, Approaches, Aprons (including Delete Records) and Helipads
        Coordinates = reader.ReadCoordinates();
        TowerCoordinates = reader.ReadCoordinates();
        MagneticVariation = (MagneticVariation)reader.ReadSingle();
        Identifier = new ShiftedIcaoIdentifier(reader.ReadUInt32());
        Region = new IcaoIdentifier(reader.ReadUInt32());
        FuelTypeInfo = reader.ReadUInt32();

        _ = reader.ReadByte();
        TrafficScalar = reader.ReadByte() / 255.0;
        IsSloped = reader.ReadUInt16() == 1;

        if (Type is AirportType.P3Dv5)
        {
            // P3D number of Approaches appears at end of airport section
            _ = reader.ReadBytes(4);
        }

        MapAirportData(reader);
    }

    public AirportType Type => (AirportType)Id;

    public int NumberOfRunways => Subsections.OfType<AirportRunwayRecord>().Count();

    public int NumberOfCom => Subsections.OfType<AirportComRecord>().Count();

    public int NumberOfStarts => Subsections.OfType<AirportRunwayStartRecord>().Count();

    public int NumberOfApproaches => Subsections.OfType<AirportApproachRecord>().Count();

    public int NumberOfAprons => Subsections.OfType<AirportApronRecord>().Count();

    public int NumberOfDeletes => Subsections.OfType<DeleteAirportRecord>().Count();

    public int NumberOfHelipads => Subsections.OfType<HelipadRecord>().Count();

    public Coordinate Coordinates { get; }

    public Coordinate TowerCoordinates { get; }

    public MagneticVariation MagneticVariation { get; }

    public ShiftedIcaoIdentifier Identifier { get; }

    public IcaoIdentifier Region { get; }

    public uint FuelTypeInfo { get; }

    public double TrafficScalar { get; }

    public bool IsSloped { get; }

    public ICollection<BglRecord> Subsections { get; } = new List<BglRecord>();

    private void MapAirportData(BglBinaryReader reader)
    {
        while (reader.Position < EndPosition)
        {
            var id = (AirportSubsectionDataType)reader.ReadUInt16();
            var record = BglRecordFactory.Create(id, Type, reader);

            if (record is null) continue;
            Subsections.Add(record);
        }
    }
}