using BglReader.Airport;

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

    public Qmid QmidA { get; set; }

    public Qmid? QmidB { get; set; }

    public uint RecordsCount { get; set; }

    public uint Offset { get; set; }

    public uint Size { get; set; }

    public ISubsectionData Data { get; set; }

    public void MapData(SectionType sectionType, BinaryReader reader)
    {
        var iterationPosition = reader.BaseStream.Position;
        Data = sectionType switch
        {
            SectionType.Airport => AirportSubsectionData.Create(reader, iterationPosition),
            _ => null,
        };
    }
}