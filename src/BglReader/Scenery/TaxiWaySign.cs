namespace BglReader.Scenery;

public sealed record TaxiWaySign(
    Coordinate Coordinates,
    short Pitch,
    short Bank,
    short Heading,
    TaxiSignFlags Flags,
    TaxiSignSize Size,
    TaxiSignJustification Justification,
    string Label);