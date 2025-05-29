using BglReader.Generic;
using BglReader.Navigation;

namespace BglReader.Airport;

public class AirportSubsectionData : BglRecord
{
    public AirportSubsectionData(
        BinaryReader reader) : base(reader, false)
    {
        NumberOfRunways = reader.ReadByte();
        NumberOfCom = reader.ReadByte();
        NumberOfStarts = reader.ReadByte();
        NumberOfApproaches = reader.ReadByte();
        ApronInfo = reader.ReadByte();
        NumberOfHelipads = reader.ReadByte();
        Coordinates = new Coordinate(reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32());
        TowerCoordinates = new Coordinate(reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32());
        MagneticVariation = (MagneticVariation)reader.ReadSingle();
        IcaoIdentifier = IcaoIdentifier.Parse(reader.ReadUInt32(), true);
        RegionIdentifier = IcaoIdentifier.Parse(reader.ReadUInt32());
        FuelTypeInfo = reader.ReadUInt32();
        _ = reader.ReadBytes(8); // Throwaway FSX info + padding

        MapAirportData(reader);
    }

    public byte NumberOfRunways { get; }

    public byte NumberOfCom { get; }

    public byte NumberOfStarts { get; }

    public uint NumberOfApproaches { get; }

    public byte ApronInfo { get; }

    public byte NumberOfHelipads { get; }

    public Coordinate Coordinates { get; }

    public Coordinate TowerCoordinates { get; }

    public MagneticVariation MagneticVariation { get; }

    public IcaoIdentifier IcaoIdentifier { get; }

    public IcaoIdentifier RegionIdentifier { get; }

    public uint FuelTypeInfo { get; }

    public ICollection<BglRecord> Subsections { get; } = new List<BglRecord>();

    private void MapAirportData(BinaryReader reader)
    {
        var recordFinalPosition = GetRecordStartPosition() + Size;
        while (reader.BaseStream.Position < recordFinalPosition)
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
                AirportSubsectionDataType.Com => new AirportRunwayComRecord(reader),
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
                    new AirportTaxiwayParkingRecord(reader),
                AirportSubsectionDataType.TaxiPath or AirportSubsectionDataType.TaxiPathP3DV4
                    or AirportSubsectionDataType.TaxiPathP3DV5 => new AirportTaxiPathRecord(reader),
                AirportSubsectionDataType.TaxiName => new AirportTaxiName(reader),
                AirportSubsectionDataType.Jetway => new AirportJetwayRecord(reader),
                AirportSubsectionDataType.Approach => new AirportApproachRecord(reader),
                AirportSubsectionDataType.Waypoint => new WaypointRecord(reader),
                AirportSubsectionDataType.BlastFence or AirportSubsectionDataType.BoundaryFence =>
                    new AirportFenceRecord(reader),
                AirportSubsectionDataType.Unknown => null,
                _ => null,
            };

            if (record is null) continue;

            Subsections.Add(record);
        }

        reader.BaseStream.Position = recordFinalPosition;
        return;
    }
}