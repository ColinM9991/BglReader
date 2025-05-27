namespace BglReader.Navigation;

public class BoundaryRecord : BglRecord
{
    public BoundaryRecord(BinaryReader reader) : base(reader, false)
    {
        Type = reader.ReadByte();

        var altitudeTypeFlags = reader.ReadByte();

        MaximumAltitudeType = altitudeTypeFlags & 0xF;
        MinimumAltitudeType = (altitudeTypeFlags >> 4) & 0xF;

        MinimumCoordinates = new Coordinate(reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32());
        MaximumCoordinates = new Coordinate(reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32());

        Name = new NameRecord(reader, shouldRewind: false);
    }
    
    public byte Type { get; }
    
    public int MaximumAltitudeType { get; }
    
    public int MinimumAltitudeType { get; }
    
    public Coordinate MinimumCoordinates { get; }
    
    public Coordinate MaximumCoordinates { get; }
    
    public NameRecord Name { get; }
}