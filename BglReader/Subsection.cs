using BglReader.Airport;
using BglReader.NameList;
using BglReader.Navigation;

namespace BglReader;

public class Subsection : BglNode
{
    public Subsection(
        SectionType sectionType,
        BinaryReader reader)
    {
        var dwordA = reader.ReadUInt32();
        var dwordB = sectionType is SectionType.PopulationDensity or SectionType.TerrainIndex
            or >= SectionType.TerrainElevation and <= SectionType.TerrainRegion
            or >= SectionType.TerrainSeasonJan and <= SectionType.TerrainPhotoNight
            ? reader.ReadUInt32()
            : 0;

        Qmid = new Qmid(dwordA, dwordB);

        RecordsCount = reader.ReadUInt32();
        Offset = reader.ReadUInt32();
        Size = reader.ReadUInt32();
    }

    public Qmid Qmid { get; }

    /// <summary>
    /// Gets the number of records within this subsection.
    /// </summary>
    /// <remarks>
    /// For a NameList, this will be the number of ICAO sub-records.
    /// </remarks>
    public uint RecordsCount { get; }

    public uint Offset { get; }

    public uint Size { get; }

    public ICollection<BglNode> Data { get; } = new List<BglNode>();

    public void MapData(SectionType sectionType, BinaryReader reader)
    {
        const int nameListSize = 1;
        reader.BaseStream.Position = Offset;

        var numberOfRecords = sectionType is SectionType.NameList
            ? nameListSize
            : RecordsCount;

        for (var i = 0; i < numberOfRecords; i++)
        {
            BglNode? data = sectionType switch
            {
                SectionType.Airport => new AirportSubsectionData(reader),
                SectionType.BglRunway => new BglRunwayRecord(reader),
                SectionType.Waypoint => new WaypointRecord(reader),
                SectionType.Tacan => new TacanRecord(reader),
                SectionType.IlsVor => new IlsVorRecord(reader),
                SectionType.Ndb => new NdbRecord(reader),
                SectionType.SceneryObject => null, // TODO
                SectionType.Marker => new MarkerRecord(reader),
                SectionType.Boundary => new BoundaryRecord(reader),
                SectionType.Geopol => new GeopolRecord(reader),
                SectionType.NdbIcaoIndex
                    or SectionType.TacanIndex
                    or SectionType.VorIlsIcaoIndex
                    or SectionType.WaypointIcaoIndex => new NavigationIndexRecord(sectionType, reader),
                SectionType.NameList => new NameListRecord(reader),
                _ => null,
            };

            if (data is not null) Data.Add(data);
        }
    }
}