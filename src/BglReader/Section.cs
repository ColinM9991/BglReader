using BglReader.Generic;

namespace BglReader;

public class Section : BglNode
{
    public Section(
        BglBinaryReader reader) : base(reader)
    {
        Type = (SectionType)reader.ReadUInt32();
        var subsectionSizeValue = reader.ReadUInt32();
        SubsectionSize = ((subsectionSizeValue & 0x10000) | 0x40000) >> 0x0E;
        SubsectionsCount = reader.ReadInt32();
        SubsectionOffset = reader.ReadUInt32();
        TotalSizeOfSubsections = reader.ReadUInt32();
        Subsections = new Subsection[SubsectionsCount];
    }

    public SectionType Type { get; }

    public uint SubsectionSize { get; }

    public int SubsectionsCount { get; }

    public uint SubsectionOffset { get; }

    public uint TotalSizeOfSubsections { get; }

    protected override long EndPosition => StartPosition + SubsectionSize;

    public Subsection[] Subsections { get; }

    public void AddSubsections(BglBinaryReader reader)
    {
        for (var i = 0; i < SubsectionsCount; i++)
        {
            Subsections[i] = new Subsection(Type, reader);
        }
    }
}