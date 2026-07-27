namespace BglReader.Airport;

public class AirportSummaryP3DRecord : AirportSummaryRecord
{
    public AirportSummaryP3DRecord(ushort id, BglBinaryReader reader) : base(id, reader)
    {
        MaterialSet = new Guid(reader.ReadBytes(16));
    }
    
    public Guid? MaterialSet { get; }
}