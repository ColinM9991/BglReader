using BglReader.Attributes.BinaryAttributes;
using BglReader.Generic;

namespace BglReader.Airport.Subsections.Taxi;

[BinarySerializable]
public partial class AirportTaxiNameRecord : BglRecord
{
    [Binary(1)]
    public ushort NumberOfRecords { get; }

    [Binary(2)]
    [BinaryReader(typeof(TaxiNameReader))]
    [BinaryCollection(nameof(NumberOfRecords))]
    public ICollection<string> Records { get; }
}