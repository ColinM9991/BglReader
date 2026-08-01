using BglReader.Airport.Subsections.Types;
using BglReader.Generic;

namespace BglReader.Airport.Subsections.RunwayDetails;

[BinarySerializable]
public partial class AirportVasiSubRecord : BglRecord
{
    [Binary(1)]
    public VasiType Type { get; }

    [Binary(2)]
    public float BiasX { get; }

    [Binary(3)]
    public float BiasZ { get; }

    [Binary(4)]
    public float Spacing { get; }

    [Binary(5)]
    public float Pitch { get; }
}