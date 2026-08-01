using BglReader.Generic;

namespace BglReader.Airport.Subsections.Taxi;

[BinarySerializable]
public partial class AirportTaxiPathRecord : BglRecord
{
    [Binary(1)]
    public ushort NumberOfPaths { get; }

    [Binary(2)]
    [BinaryCollection(nameof(NumberOfPaths))]
    public ICollection<TaxiPath> Paths { get; }
}