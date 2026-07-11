using System.Text;
using BglReader.Generic;

namespace BglReader.Airport;

public class AirportTaxiName : BglRecord
{
    public AirportTaxiName(BinaryReader reader) : base(reader)
    {
        NumberOfRecords = reader.ReadUInt16();

        Records = Enumerable.Range(0, NumberOfRecords)
            .Select(i => Encoding.UTF8.GetString(reader.ReadBytes(8)))
            .ToList();
    }

    public ushort NumberOfRecords { get; }

    public ICollection<string> Records { get; } = [];
}