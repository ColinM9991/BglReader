namespace BglReader.Navigation;

public class NavigationIndexRecord : BglNode
{
    public NavigationIndexRecord(
        SectionType sectionType,
        BinaryReader reader)
    {
        Type = sectionType;
        Identifier = IcaoIdentifier.Parse(reader.ReadUInt32(), true);

        var regionFlags = reader.ReadUInt32();
        
        Region = IcaoIdentifier.Parse(regionFlags & 0x7FF);
        Airport = IcaoIdentifier.Parse((regionFlags >> 11) & 0x1FFFFF);

        Qmid = new Qmid(reader.ReadUInt16(), reader.ReadUInt16(), 9);
    }
    
    public SectionType Type { get; }
    
    public IcaoIdentifier Identifier { get; }
    
    public IcaoIdentifier Region { get; }
    
    public IcaoIdentifier Airport { get; }
    
    public Qmid Qmid { get; }
}