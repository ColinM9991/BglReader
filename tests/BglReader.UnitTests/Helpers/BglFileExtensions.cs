using BglReader.Airport;

namespace BglReader.UnitTests.Helpers;

public static class BglFileExtensions
{
    extension(BglFile bglFile)
    {
        public AirportSubsectionData GetAirport(string airportIdentifier) => bglFile.Sections
            .Where(x => x.Type is SectionType.Airport)
            .SelectMany(x => x.Subsections)
            .SelectMany(x => x.Data)
            .OfType<AirportSubsectionData>()
            .Single(x => string.Equals(airportIdentifier, x.Identifier.ToString(), StringComparison.OrdinalIgnoreCase));
    }

    extension(AirportSubsectionData subsection)
    {
        public AirportRunwayRecord? GetRunway(byte runwayNumber) => subsection.Subsections
            .OfType<AirportRunwayRecord>()
            .Single(x => x.RunwayNumber == runwayNumber);
    }
}