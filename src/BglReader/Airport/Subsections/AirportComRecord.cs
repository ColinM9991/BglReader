using BglReader.Airport.Subsections.Types;
using BglReader.Generic;

namespace BglReader.Airport.Subsections;

[BinarySerializable]
public partial class AirportComRecord : BglRecord
{
    [Binary(1)]
    public ComType Type { get; }

    [Binary(2)]
    public byte TypeHigherByte { get; set; }
    
    [Binary(3)]
    [BinaryReader(typeof(FrequencyValueReader))]
    public Frequency Frequency { get; }

    [Binary(4)]
    [BinaryString(nameof(RemainingBytes))]
    public string Name { get; }
}