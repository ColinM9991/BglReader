using BglReader.Generic;

namespace BglReader.Navigation;

public class MarkerRecord : BglRecord
{
    public MarkerRecord(BinaryReader reader) : base(reader, false)
    {
        Heading = reader.ReadByte();
        Type = (MarkerType)reader.ReadByte();
        Coordinates = new Coordinate(reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32());
        Identifier = new ShiftedIcaoIdentifier(reader.ReadUInt32());
        Region = new IcaoIdentifier(reader.ReadUInt16());
    }
    
    public ushort Heading { get; }
    
    public MarkerType Type { get; }
    
    public Coordinate Coordinates { get; }
    
    public ShiftedIcaoIdentifier Identifier { get; }
    
    public IcaoIdentifier Region { get; }
}