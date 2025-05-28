using System.Text;
using BglReader.Generic;

namespace BglReader.Airport;

public class AirportTaxiName : BglRecord
{
    public AirportTaxiName(BinaryReader reader) : base(reader)
    {
        NumberOfRecords = reader.ReadUInt16();
        
        MapRecords(reader);
    }

    public ushort NumberOfRecords { get; }

    public ICollection<string> Records { get; } = new List<string>();

    private void MapRecords(BinaryReader reader)
    {
        if (NumberOfRecords == 0) return;

        for (var record = 0; record < NumberOfRecords; record++)
        {
            Records.Add(Encoding.UTF8.GetString(reader.ReadBytes(8)));
        }
    }
}