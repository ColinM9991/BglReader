using BglReader.Generic;

namespace BglReader.Airport.Subsections.Taxi;

public class AirportTaxiwayParkingRecord : BglRecord
{
    public AirportTaxiwayParkingRecord(
        ushort id,
        BglBinaryReader reader, AirportType airportType) : base(id, reader)
    {
        NumberOfParkingRecords = reader.ReadUInt16();
        
        ParkingRecords = Enumerable.Range(0, NumberOfParkingRecords)
            .Select(_ => TaxiParking.FromBgl(reader, airportType))
            .ToList();
    }

    public ushort NumberOfParkingRecords { get; }

    public ICollection<TaxiParking> ParkingRecords { get; }
}