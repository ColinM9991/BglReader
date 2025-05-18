namespace BglReader.Airport;

public class AirportSubsectionData : ISubsectionData
{
    public AirportSubsectionData(
        BinaryReader reader,
        long iterationPosition)
    {
        Id = reader.ReadUInt16();
        Size = reader.ReadUInt32();
        NumberOfRunways = reader.ReadByte();
        NumberOfCom = reader.ReadByte();
        NumberOfStarts = reader.ReadByte();
        NumberOfApproaches = reader.ReadByte();
        ApronInfo = reader.ReadByte();
        NumberOfHelipads = reader.ReadByte();
        Latitude = reader.ReadUInt32();
        Longitude = reader.ReadUInt32();
        Altitude = reader.ReadUInt32();
        TowerLongitude = reader.ReadUInt32();
        TowerLatitude = reader.ReadUInt32();
        TowerAltitude = reader.ReadUInt32();
        MagneticVariation = reader.ReadSingle();
        IcaoIdentifier = IcaoIdentifier.Parse(reader.ReadUInt32(), true);
        RegionIdentifier = IcaoIdentifier.Parse(reader.ReadUInt32(), true);
        FuelTypeInfo = reader.ReadUInt32();
        _ = reader.ReadBytes(8); // Throwaway FSX info + padding

        MapAirportData(reader, iterationPosition);
    }

    public ushort Id { get; set; }

    public uint Size { get; set; }

    public byte NumberOfRunways { get; set; }

    public byte NumberOfCom { get; set; }

    public byte NumberOfStarts { get; set; }

    public byte NumberOfApproaches { get; set; }

    public byte ApronInfo { get; set; }

    public byte NumberOfHelipads { get; set; }

    public uint Longitude { get; set; }

    public uint Latitude { get; set; }

    public uint Altitude { get; set; }

    public uint TowerLongitude { get; set; }

    public uint TowerLatitude { get; set; }

    public uint TowerAltitude { get; set; }

    public float MagneticVariation { get; set; }

    public IcaoIdentifier IcaoIdentifier { get; set; }

    public IcaoIdentifier RegionIdentifier { get; set; }

    public uint FuelTypeInfo { get; set; }

    public ICollection<BglRecord> Subsections { get; set; } = new List<BglRecord>();

    public static ISubsectionData Create(BinaryReader reader, long iterationPosition) =>
        new AirportSubsectionData(reader, iterationPosition);

    private void MapAirportData(BinaryReader reader, long iterationStartPos)
    {
        while (reader.BaseStream.Position < iterationStartPos + Size)
        {
            var iterationPosition = reader.BaseStream.Position;

            var id = reader.ReadUInt16();

            BglRecord? record = (AirportSubsectionDataType?)id switch
            {
                AirportSubsectionDataType.Name => new AirportNameRecord(reader),
                AirportSubsectionDataType.IncludedTowerSceneryObject => new TowerSceneryObjectRecord(reader),
                AirportSubsectionDataType.Runway or AirportSubsectionDataType.RunwayP3DV4 => new
                    AirportRunwayRecord(reader,
                        iterationPosition),
                AirportSubsectionDataType.Helipad => new HelipadRecord(reader),
                AirportSubsectionDataType.Start => new AirportRunwayStartRecord(reader),
                AirportSubsectionDataType.Com => new AirportRunwayComRecord(reader, iterationPosition),
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
                AirportSubsectionDataType.Approach => new AirportApproachRecord(reader, iterationPosition),
                AirportSubsectionDataType.Waypoint => new AirportWaypointRecord(reader),
                AirportSubsectionDataType.BlastFence or AirportSubsectionDataType.BoundaryFence => null,
                AirportSubsectionDataType.Unknown => null,
                _ => null,
            };

            if (record is not null)
            {
                Subsections.Add(record);
            }
        }
    }
}