namespace BglReader;

public class BglFile
{
    public BglFile(
        FileStream file)
    {
        FileName = Path.GetFileName(file.Name);
        using var reader = new BinaryReader(file);
        
        Header = new Header(reader);
        Sections = new Section[Header.NumberOfSections];
        
        MapSections(reader);
    }

    public string FileName { get; }

    public Header Header { get; }

    public Section[] Sections { get; }

    private void MapSections(BinaryReader reader)
    {
        for (var i = 0; i < Header.NumberOfSections; i++)
        {
            Sections[i] = new Section(reader);
        }

        foreach (var section in Sections)
        {
            section.AddSubsections(reader);
        }

        foreach (var section in Sections)
        {
            foreach (var subsection in section.Subsections)
            {
                subsection.MapData(section.Type, reader);
            }
        }
    }
}