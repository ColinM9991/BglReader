using BglReader.Generic;

namespace BglReader.Airport.Subsections.Taxi;

[BinarySerializable]
public partial class AirportTaxiwayPoint : BglRecord
{
    [Binary(1)]
    public ushort NumberOfPoints { get; }

    [Binary(2)]
    [BinaryCollection(nameof(NumberOfPoints))]
    public ICollection<TaxiWayPoint> Points { get; } = new List<TaxiWayPoint>();
}