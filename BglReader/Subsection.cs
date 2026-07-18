using BglReader.Generic;

namespace BglReader;

public class Subsection : BglNode
{
    public Subsection(
        SectionType sectionType,
        BglBinaryReader reader)
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

    public void MapData(SectionType sectionType, BglBinaryReader reader)
    {
        const int nameListSize = 1;
        reader.Seek(Offset);

        var numberOfRecords = sectionType is SectionType.NameList
            ? nameListSize
            : RecordsCount;

        for (var i = 0; i < numberOfRecords; i++)
        {
            var data = BglNodeFactory.Create(sectionType, reader);
            if (data is not null) Data.Add(data);
        }
    }
}