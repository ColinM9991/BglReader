using BglReader.Generic;

namespace BglReader.Airport.Subsections.Taxi;

[BinarySerializable]
public partial class AirportTaxiwayParkingRecord : BglRecord
{
    [Binary(1)]
    public ushort NumberOfParkingRecords { get; }

    [Binary(2)]
    [BinaryCollection(nameof(NumberOfParkingRecords))]
    public ICollection<TaxiParking> ParkingRecords { get; }
}