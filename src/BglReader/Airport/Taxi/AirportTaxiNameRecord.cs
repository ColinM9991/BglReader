using System.Text;
using BglReader.Generic;

namespace BglReader.Airport.Taxi;

public class AirportTaxiNameRecord : BglRecord
{
    public AirportTaxiNameRecord(BglBinaryReader reader) : base(reader)
    {
        NumberOfRecords = reader.ReadUInt16();

        Records = Enumerable.Range(0, NumberOfRecords)
            .Select(i => reader.ReadString(8))
            .ToList();
    }

    public ushort NumberOfRecords { get; }

    public ICollection<string> Records { get; }
}