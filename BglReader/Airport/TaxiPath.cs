namespace BglReader.Airport;

public readonly struct TaxiPath(
    ushort startIndex,
    ushort pathFlags,
    byte typeFlags,
    byte runwayTaxiFlags,
    byte bitfield,
    byte surface,
    float width,
    float weightLimit);