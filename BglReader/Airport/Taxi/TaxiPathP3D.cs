namespace BglReader.Airport.Taxi;

public class TaxiPathP3D : TaxiPath
{
    public TaxiPathP3D(BglBinaryReader reader) : base(reader)
    {
        Material = new Guid(reader.ReadBytes(16));

        _ = reader.ReadBytes(4); // TODO Unknown. Repeated TaxiNameIndex in bytes 3-4?
    }
    
    public Guid Material { get; }
}