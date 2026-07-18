using System.Text;
using BglReader.Generic;

namespace BglReader.Airport.Taxi;

public class AirportTaxiNameRecord : BglRecord
{
    public AirportTaxiNameRecord(BinaryReader reader) : base(reader)
    {
        NumberOfRecords = reader.ReadUInt16();

        Records = Enumerable.Range(0, NumberOfRecords)
            .Select(i => Encoding.UTF8.GetString(reader.ReadBytes(8).TakeWhile(x => x != 0).ToArray()))
            .ToList();
    }

    public ushort NumberOfRecords { get; }

    public ICollection<string> Records { get; }
}