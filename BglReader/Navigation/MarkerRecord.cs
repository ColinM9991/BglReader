using BglReader.Generic;

namespace BglReader.Navigation;

public class MarkerRecord : BglRecord
{
    public MarkerRecord(BinaryReader reader) : base(reader, false)
    {
        Heading = reader.ReadByte();
        Type = (MarkerType)reader.ReadByte();
        Coordinates = new Coordinate(reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32());
        Identifier = IcaoIdentifier.Parse(reader.ReadUInt32(), true);
        Region = IcaoIdentifier.Parse(reader.ReadUInt16(), true);
    }
    
    public ushort Heading { get; }
    
    public MarkerType Type { get; }
    
    public Coordinate Coordinates { get; }
    
    public IcaoIdentifier Identifier { get; }
    
    public IcaoIdentifier Region { get; }
}