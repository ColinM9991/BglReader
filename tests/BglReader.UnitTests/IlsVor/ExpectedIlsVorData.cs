using BglReader.Airport;
using BglReader.Navigation;

namespace BglReader.UnitTests.IlsVor;

public record ExpectedIlsVorData(
    IlsVorType Type,
    Coordinate Coordinates,
    Frequency Frequency,
    MagneticVariation MagneticVariation,
    float Range,
    string RegionIdentifier,
    bool IsDme,
    bool IsBackCourse,
    bool HasGlideslope,
    bool IsDmePresent,
    bool NavTrue);

public record ExpectedGlideSlopeData(
    Coordinate Coordinates,
    float Pitch,
    float Range);

public record ExpectedLocalizerData(
    byte RunwayNumber,
    RunwayDesignator Designator,
    float Heading,
    float BeamWidth);