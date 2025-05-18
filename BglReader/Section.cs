namespace BglReader;

public class Section
{
    public Section(
        BinaryReader reader)
    {
        Type = (SectionType)reader.ReadUInt32();
        var subsectionSizeValue = reader.ReadUInt32();
        SubsectionSize = ((subsectionSizeValue & 0x10000) | 0x40000) >> 0x0E;
        SubsectionsCount = reader.ReadUInt32();
        SubsectionOffset = reader.ReadUInt32();
        TotalSizeOfSubsections = reader.ReadUInt32();
        Subsections = new Subsection[SubsectionsCount];
    }

    public SectionType Type { get; }

    public uint SubsectionSize { get; }

    public uint SubsectionsCount { get; }

    public uint SubsectionOffset { get; }

    public uint TotalSizeOfSubsections { get; }

    public Subsection[] Subsections { get; set; }

    public void AddSubsections(BinaryReader reader)
    {
        for (var i = 0; i < SubsectionsCount; i++)
        {
            Subsections[i] = new Subsection(Type, reader);
        }
    }
}