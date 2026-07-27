using BglReader.Generic;

namespace BglReader.Airport.Subsections;

public class AirportJetwayRecord : BglRecord
{
    public AirportJetwayRecord(ushort id, BglBinaryReader reader) : base(id, reader)
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