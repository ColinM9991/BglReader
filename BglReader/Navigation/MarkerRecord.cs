using BglReader.Generic;

namespace BglReader.Navigation;

public class MarkerRecord : BglRecord
{
    public MarkerRecord(BglBinaryReader reader) : base(reader, false)
    {
        Heading = reader.ReadByte();
        Type = (MarkerType)reader.ReadByte();
        Coordinates = reader.ReadCoordinates();
        Identifier = new ShiftedIcaoIdentifier(reader.ReadUInt32());
        Region = new IcaoIdentifier(reader.ReadUInt16());
        _ = reader.ReadBytes(2); // TODO Unknown
    }
    
    public ushort Heading { get; }
    
    public MarkerType Type { get; }
    
    public Coordinate Coordinates { get; }
    
    public ShiftedIcaoIdentifier Identifier { get; }
    
    public IcaoIdentifier Region { get; }
}