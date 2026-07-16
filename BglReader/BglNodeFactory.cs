using BglReader.Airport;
using BglReader.Generic;
using BglReader.NameList;
using BglReader.Navigation;

namespace BglReader;

public static class BglNodeFactory
{
    public static BglNode? Create(SectionType sectionType, BinaryReader reader) => sectionType switch
    {
        SectionType.Airport => new AirportRecord(reader),
        SectionType.AirportSummary or SectionType.AirportSummaryP3D => new AirportSummaryRecord(reader),
        SectionType.Waypoint => new WaypointRecord(reader),
        SectionType.Tacan => new TacanRecord(reader),
        SectionType.IlsVor => new IlsVorRecord(reader),
        SectionType.Ndb => new NdbRecord(reader),
        SectionType.SceneryObject => SceneryBglRecord.GetSceneryBglRecord(reader),
        SectionType.Marker => new MarkerRecord(reader),
        SectionType.Boundary => new BoundaryRecord(reader), // Unused in APX, AVX, NVX
        SectionType.Geopol => new GeopolRecord(reader), // Incorrect mapping internally - Unused in APX, AVX, NVX
        SectionType.NdbIcaoIndex
            or SectionType.TacanIndex
            or SectionType.VorIlsIcaoIndex
            or SectionType.WaypointIcaoIndex => new NavigationIndexRecord(sectionType, reader),
        SectionType.NameList => new NameListRecord(reader),
        _ => null,
    };
}