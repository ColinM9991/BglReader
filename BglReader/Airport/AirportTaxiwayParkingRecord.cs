namespace BglReader.Airport;

public class AirportTaxiwayParkingRecord : BglRecord
{
    public AirportTaxiwayParkingRecord(BinaryReader reader) : base(reader)
    {
        NumberOfParkingRecords = reader.ReadUInt16();
        MapTaxiwayParkingRecords(reader);
    }

    public ushort NumberOfParkingRecords { get; }

    public ICollection<TaxiParking> ParkingRecords { get; } = new List<TaxiParking>();

    public void MapTaxiwayParkingRecords(BinaryReader reader)
    {
        if (NumberOfParkingRecords == 0) return;

        for (var parkingRecord = 0; parkingRecord < NumberOfParkingRecords; parkingRecord++)
        {
            ParkingRecords.Add(new TaxiParking(reader));
        }
    }
}