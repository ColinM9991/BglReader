using BglReader.Airport;
using BglReader.Navigation;

namespace BglReader;

public class Subsection
{
    public Subsection(
        SectionType sectionType,
        BinaryReader reader)
    {
        QmidA = new Qmid(reader.ReadUInt32());

        if (sectionType is SectionType.PopulationDensity or SectionType.TerrainIndex
            or (>= SectionType.TerrainElevation and <= SectionType.TerrainRegion)
            or (>= SectionType.TerrainSeasonJan and <= SectionType.TerrainPhotoNight))
        {
            QmidB = new Qmid(reader.ReadUInt32());
        }

        RecordsCount = reader.ReadUInt32();
        Offset = reader.ReadUInt32();
        Size = reader.ReadUInt32();
    }

    public Qmid QmidA { get; }

    public Qmid? QmidB { get; }

    public uint RecordsCount { get; }

    public uint Offset { get; }

    public uint Size { get; }

    public ICollection<BglRecord> Data { get; } = new List<BglRecord>();

    public void MapData(SectionType sectionType, BinaryReader reader)
    {
        var originalPosition = reader.BaseStream.Position;
        for (var i = 0; i < RecordsCount; i++)
        {
            BglRecord data = sectionType switch
            {
                SectionType.Airport => new AirportSubsectionData(reader),
                SectionType.Waypoint => new WaypointRecord(reader),
                _ => null,
            };

            if (data is not null) Data.Add(data);
        }

        reader.BaseStream.Position = originalPosition + Size;
    }
}