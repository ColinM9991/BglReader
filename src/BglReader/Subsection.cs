using BglReader.Generic;

namespace BglReader;

public class Subsection : BglNode
{
    private readonly uint _recordsCount;

    public Subsection(
        SectionType sectionType,
        BglBinaryReader reader) : base(reader)
    {
        Type = sectionType;
        var dwordA = reader.ReadUInt32();
        var dwordB = sectionType is SectionType.PopulationDensity or SectionType.TerrainIndex
            or >= SectionType.TerrainElevation and <= SectionType.TerrainRegion
            or >= SectionType.TerrainSeasonJan and <= SectionType.TerrainPhotoNight
            ? reader.ReadUInt32()
            : 0;

        Qmid = new Qmid(dwordA, dwordB);

        _recordsCount = reader.ReadUInt32();
        Offset = reader.ReadUInt32();
        Size = reader.ReadUInt32();
    }

    public SectionType Type { get; }

    public Qmid Qmid { get; }

    /// <summary>
    /// Gets the number of records within this subsection.
    /// </summary>
    /// <remarks>
    /// For a NameList, this will be the number of ICAO sub-records.
    /// </remarks>
    public uint RecordsCount => Type is SectionType.NameList
        ? 1
        : _recordsCount;

    public uint Offset { get; }

    protected override long EndPosition => StartPosition + Size;

    public uint Size { get; }

    public ICollection<BglNode> Data { get; } = new List<BglNode>();

    public void MapData(BglBinaryReader reader)
    {
        reader.Seek(Offset);

        for (var i = 0; i < RecordsCount; i++)
        {
            var data = BglNodeFactory.Create(Type, reader);
            if (data is null) continue;

            data.AssertEndPosition();
            Data.Add(data);
        }
    }
}