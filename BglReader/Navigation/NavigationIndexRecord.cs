using BglReader.Generic;
using BglReader.ValueObjects;

namespace BglReader.Navigation;

public class NavigationIndexRecord : BglNode
{
    public NavigationIndexRecord(
        SectionType sectionType,
        BinaryReader reader)
    {
        Type = sectionType;
        Identifier = new ShiftedIcaoIdentifier(reader.ReadUInt32());

        RegionFlags = new RegionIdentifierFlags(reader.ReadUInt32());

        Qmid = new Qmid(reader.ReadUInt16(), reader.ReadUInt16(), 9);
    }
    
    public SectionType Type { get; }
    
    public ShiftedIcaoIdentifier Identifier { get; }
    
    public RegionFlags RegionFlags { get; }
    
    public Qmid Qmid { get; }
}