namespace BglReader.Airport;

public class AirportSummaryP3DRecord : AirportSummaryRecord
{
    public AirportSummaryP3DRecord(BglBinaryReader reader) : base(reader)
    {
        MaterialSet = new Guid(reader.ReadBytes(16));
    }
    
    public Guid? MaterialSet { get; }
}