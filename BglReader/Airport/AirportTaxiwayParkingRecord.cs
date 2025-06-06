using BglReader.Generic;

namespace BglReader.Airport;

public class AirportTaxiwayParkingRecord : BglRecord
{
    public AirportTaxiwayParkingRecord(BinaryReader reader, AirportType airportType) : base(reader)
    {
        NumberOfParkingRecords = reader.ReadUInt16();
        MapTaxiwayParkingRecords(reader, airportType);
    }

    public ushort NumberOfParkingRecords { get; }

    public ICollection<TaxiParking> ParkingRecords { get; } = new List<TaxiParking>();

    public void MapTaxiwayParkingRecords(BinaryReader reader, AirportType airportType)
    {
        if (NumberOfParkingRecords == 0) return;

        for (var parkingRecord = 0; parkingRecord < NumberOfParkingRecords; parkingRecord++)
        {
            ParkingRecords.Add(new TaxiParking(reader, airportType));
        }
    }
}