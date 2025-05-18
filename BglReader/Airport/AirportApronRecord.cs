namespace BglReader.Airport;

public class AirportApronRecord : AirportApronBaseRecord
{
    public AirportApronRecord(
        BinaryReader reader) : base(reader)
    {
        _ = reader.ReadBytes(21);
        NumberOfVertices = reader.ReadUInt16();
        MapVertices(reader);
    }
}