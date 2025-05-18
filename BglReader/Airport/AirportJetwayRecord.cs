namespace BglReader.Airport;

public class AirportJetwayRecord : BglRecord
{
    public AirportJetwayRecord(BinaryReader reader) : base(reader)
    {
        ParkingNumber = reader.ReadUInt16();
        GateName = reader.ReadUInt16();
        SceneryObjectSize = reader.ReadUInt32();

        _ = reader.ReadBytes((int)SceneryObjectSize); // TODO: Scenery Object
    }
    
    public ushort ParkingNumber { get; }
    
    public ushort GateName { get; }
    
    public uint SceneryObjectSize { get; }
}