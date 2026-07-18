using BglReader.Generic;

namespace BglReader.Airport.Taxi;

public class AirportTaxiwayParkingRecord : BglRecord
{
    public AirportTaxiwayParkingRecord(BinaryReader reader, AirportType airportType) : base(reader)
    {
        NumberOfParkingRecords = reader.ReadUInt16();
        
        ParkingRecords = Enumerable.Range(0, NumberOfParkingRecords)
            .Select(_ => TaxiParking.FromBgl(reader, airportType))
            .ToList();
    }

    public ushort NumberOfParkingRecords { get; }

    public ICollection<TaxiParking> ParkingRecords { get; }
}