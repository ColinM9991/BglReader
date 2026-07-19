namespace BglReader.Airport.Apron;

public class AirportApronRecord : AirportApronBaseRecord
{
    public AirportApronRecord(
        BglBinaryReader reader) : base(reader)
    {
        _ = reader.ReadBytes(21);
        NumberOfVertices = reader.ReadUInt16();
        MapVertices(reader);
    }
}