using BglReader.Types;

namespace BglReader.Scenery.TaxiSigns;

public sealed record TaxiWaySign(
    Coordinate Coordinates,
    Angle Pitch,
    Angle Bank,
    Angle Heading,
    TaxiSignFlags Flags,
    TaxiSignSize Size,
    TaxiSignJustification Justification,
    string Label);