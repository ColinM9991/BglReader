namespace BglReader.Airport;

public class AirportWaypointRecord : BglRecord
{
    public AirportWaypointRecord(BinaryReader reader) : base(reader)
    {
        _ = reader.ReadBytes((int)Size); // TODO
    }
}