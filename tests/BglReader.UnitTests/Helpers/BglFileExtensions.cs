using BglReader.Airport;
using BglReader.Generic;
using BglReader.Navigation;

namespace BglReader.UnitTests.Helpers;

public static class BglFileExtensions
{
    extension(BglFile bglFile)
    {
        public AirportRecord GetAirport(string airportIdentifier) => bglFile
            .GetSubsectionDataByType<AirportRecord>(SectionType.Airport)
            .Single(x => string.Equals(airportIdentifier, x.Identifier.ToString(), StringComparison.OrdinalIgnoreCase));

        public IlsVorRecord GetIlsVorRecord(string identifier) => bglFile
            .GetSubsectionDataByType<IlsVorRecord>(SectionType.IlsVor)
            .Single(x => string.Equals(identifier, x.Identifier.ToString(), StringComparison.OrdinalIgnoreCase));

        private IEnumerable<Subsection> GetSubsectionsByType(SectionType sectionType) =>
            bglFile.Sections.Where(x => x.Type == sectionType).SelectMany(x => x.Subsections);

        private IEnumerable<T> GetSubsectionDataByType<T>(SectionType sectionType) =>
            bglFile.GetSubsectionsByType(sectionType).SelectMany(x => x.Data).OfType<T>();
    }

    extension(AirportRecord subsection)
    {
        public AirportRunwayRecord GetRunway(byte runwayNumber) => subsection.Subsections
            .OfType<AirportRunwayRecord>()
            .Single(x => x.RunwayNumber == runwayNumber);
    }

    extension(AirportRunwayRecord runway)
    {
        public AirportSubReportBaseRecord GetSubRecordByType(AirportRecordDataType type) =>
            runway.SubRecords.OfType<AirportSubReportBaseRecord>().Single(x => x.Id == (int)type);

        public T GetSubRecordByType<T>(AirportRecordDataType type) where T : BglRecord =>
            runway.SubRecords.OfType<T>().Single(x => x.Id == (int)type);
    }
    
    extension(IlsVorRecord ilsVorRecord)
    {
        public T GetRecordType<T>() where T : BglRecord => ilsVorRecord.SubRecords.OfType<T>().Single();
    }
}