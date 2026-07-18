using BglReader.Generic;

namespace BglReader.Airport.Taxi;

public class AirportTaxiPathRecord : BglRecord
{
    public AirportTaxiPathRecord(BglBinaryReader reader) : base(reader)
    {
        NumberOfPaths = reader.ReadUInt16();

        Paths = Enumerable.Range(0, NumberOfPaths).Select(x => new TaxiPathP3D(reader)).ToList();
    }

    public ushort NumberOfPaths { get; }

    public ICollection<TaxiPathP3D> Paths { get; }
}