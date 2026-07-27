using BglReader.Generic;

namespace BglReader.Airport.Taxi;

public class AirportTaxiPathRecord : BglRecord
{
    public AirportTaxiPathRecord(ushort id, BglBinaryReader reader) : base(id, reader)
    {
        NumberOfPaths = reader.ReadUInt16();

        Paths = Enumerable.Range(0, NumberOfPaths).Select(x => new TaxiPathP3D(reader)).ToList();
    }

    public ushort NumberOfPaths { get; }

    public ICollection<TaxiPathP3D> Paths { get; }
}