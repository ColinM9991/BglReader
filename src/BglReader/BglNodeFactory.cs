using BglReader.Airport;
using BglReader.Generic;
using BglReader.NameList;
using BglReader.Navigation;

namespace BglReader;

public static class BglNodeFactory
{
    public static BglNode? Create(SectionType sectionType, BglBinaryReader reader)
    {
        if (IsFixedSectionNode(sectionType))
            return CreateFixedSectionNode(sectionType, reader);
        
        var id = reader.ReadUInt16();
        return sectionType switch
        {
            SectionType.Airport => new AirportRecord(id, reader),
            SectionType.AirportSummary => new AirportSummaryRecord(id, reader),
            SectionType.AirportSummaryP3D => new AirportSummaryP3DRecord(id, reader),
            SectionType.Waypoint => new WaypointRecord(id, reader),
            SectionType.Tacan => new TacanRecord(id, reader),
            SectionType.IlsVor => new IlsVorRecord(id, reader),
            SectionType.Ndb => new NdbRecord(id, reader),
            SectionType.SceneryObject => SceneryBglRecord.GetSceneryBglRecord(id, reader),
            SectionType.Marker => new MarkerRecord(id, reader),
            SectionType.Boundary => new BoundaryRecord(id, reader), // Unused in APX, AVX, NVX
            SectionType.Geopol => new GeopolRecord(id, reader), // Incorrect mapping internally - Unused in APX, AVX, NVX
            SectionType.NameList => new NameListRecord(id, reader),
            _ => null,
        };
    }

    private static bool IsFixedSectionNode(SectionType sectionType) => sectionType is SectionType.NdbIcaoIndex
        or SectionType.TacanIndex
        or SectionType.VorIlsIcaoIndex
        or SectionType.WaypointIcaoIndex;

    private static BglNode CreateFixedSectionNode(SectionType sectionType, BglBinaryReader reader) => sectionType switch
    {
        SectionType.NdbIcaoIndex
            or SectionType.TacanIndex
            or SectionType.VorIlsIcaoIndex
            or SectionType.WaypointIcaoIndex => new NavigationIndexRecord(sectionType, reader),
        _ => throw new ArgumentOutOfRangeException(nameof(sectionType), sectionType, null)
    };
}