using BglReader.Generic;
using BglReader.Navigation;

namespace BglReader.Airport;

public class AirportSubsectionData : BglRecord
{
    public AirportSubsectionData(
        BinaryReader reader) : base(reader, false)
    {
        _ = reader.ReadBytes(6); // Number of Runways, Com, Starts, Approaches, Aprons (including Delete Records) and Helipads
        Coordinates = new Coordinate(reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32());
        TowerCoordinates = new Coordinate(reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32());
        MagneticVariation = (MagneticVariation)reader.ReadSingle();
        Identifier = IcaoIdentifier.Parse(reader.ReadUInt32(), true);
        Region = IcaoIdentifier.Parse(reader.ReadUInt32());
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

    public IcaoIdentifier Identifier { get; }

    public IcaoIdentifier Region { get; }

    public uint FuelTypeInfo { get; }

    public double TrafficScalar { get; }

    public bool IsSloped { get; }

    public ICollection<BglRecord> Subsections { get; } = new List<BglRecord>();

    private void MapAirportData(BinaryReader reader)
    {
        while (reader.BaseStream.Position < GetRecordEndPosition())
        {
            var id = (AirportSubsectionDataType?)reader.ReadUInt16();

            BglRecord? record = id switch
            {
                AirportSubsectionDataType.Name => new NameRecord(reader),
                AirportSubsectionDataType.IncludedTowerSceneryObject => new TowerSceneryObjectRecord(reader),
                AirportSubsectionDataType.Runway or AirportSubsectionDataType.RunwayP3DV4 => new
                    AirportRunwayRecord(reader),
                AirportSubsectionDataType.Helipad => new HelipadRecord(reader),
                AirportSubsectionDataType.Start => new AirportRunwayStartRecord(reader),
                AirportSubsectionDataType.Com => new AirportComRecord(reader),
                AirportSubsectionDataType.DeleteAirport => new DeleteAirportRecord(reader),
                AirportSubsectionDataType.ApronFirst or AirportSubsectionDataType.ApronFirstP3DV5 => new
                    AirportApronRecord(
                        reader),
                AirportSubsectionDataType.ApronSecond or AirportSubsectionDataType.ApronSecondP3DV4
                    or AirportSubsectionDataType.ApronSecondP3DV5 => new AirportApronSecondRecord(reader),
                AirportSubsectionDataType.ApronEdgeLights => new AirportApronEdgeLightsRecord(reader),
                AirportSubsectionDataType.TaxiwayPoint or AirportSubsectionDataType.TaxiwayPointP3DV5 => new
                    AirportTaxiwayPoint(
                        reader),
                AirportSubsectionDataType.TaxiwayParking or AirportSubsectionDataType.TaxiwayParkingP3DV5
                    or AirportSubsectionDataType.TaxiwayParkingFS9 =>
                    new AirportTaxiwayParkingRecord(reader, Type),
                AirportSubsectionDataType.TaxiPath or AirportSubsectionDataType.TaxiPathP3DV4
                    or AirportSubsectionDataType.TaxiPathP3DV5 => new AirportTaxiPathRecord(reader),
                AirportSubsectionDataType.TaxiName => new AirportTaxiName(reader),
                AirportSubsectionDataType.Jetway => new AirportJetwayRecord(reader),
                AirportSubsectionDataType.Approach => new AirportApproachRecord(reader),
                AirportSubsectionDataType.Waypoint => new WaypointRecord(reader),
                AirportSubsectionDataType.BlastFence or AirportSubsectionDataType.BoundaryFence =>
                    new AirportFenceRecord(reader),
                AirportSubsectionDataType.Polygon => new AirportPolygonRecord(reader),
                _ => null,
            };

            if (record is null) continue;

            Subsections.Add(record);
        }

        reader.BaseStream.Position = GetRecordEndPosition();
    }
}