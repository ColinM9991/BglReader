using BglReader.Generic;

namespace BglReader.Airport.Subsections.Taxi;

public class AirportTaxiNameRecord : BglRecord
{
    public AirportTaxiNameRecord(ushort id, BglBinaryReader reader) : base(id, reader)
    {
        NumberOfRecords = reader.ReadUInt16();

        Records = Enumerable.Range(0, NumberOfRecords)
            .Select(i => reader.ReadString(8))
            .ToList();
    }

    public ushort NumberOfRecords { get; }

    public ICollection<string> Records { get; }
}