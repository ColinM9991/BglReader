using BglReader.Airport.Apron;
using BglReader.Airport.Taxi;
using BglReader.Generic;
using BglReader.Navigation;
using BglReader.Scenery;

namespace BglReader.Airport;

public static class BglRecordFactory
{
    public static BglRecord? Create(AirportSubsectionDataType type, AirportType airportType, BglBinaryReader reader) =>
        type switch
        {
            AirportSubsectionDataType.Name => new NameRecord(reader),
            AirportSubsectionDataType.IncludedTowerSceneryObject => new TowerSceneryObjectRecord(reader),
            AirportSubsectionDataType.Runway or AirportSubsectionDataType.RunwayP3DV4 => new
                AirportRunwayRecord(reader),
            AirportSubsectionDataType.Helipad => new HelipadRecord(reader),
            AirportSubsectionDataType.Start => new AirportRunwayStartRecord(reader),
            AirportSubsectionDataType.Com => new AirportComRecord(reader),
            AirportSubsectionDataType.DeleteAirport => new DeleteAirportRecord(reader),
            AirportSubsectionDataType.ApronFirst or AirportSubsectionDataType.ApronFirstP3DV5 => new
                AirportApronRecord(
                    reader),
            AirportSubsectionDataType.ApronSecond or AirportSubsectionDataType.ApronSecondP3DV4
                or AirportSubsectionDataType.ApronSecondP3DV5 => new AirportApronSecondRecord(reader),
            AirportSubsectionDataType.ApronEdgeLights => new AirportApronEdgeLightsRecord(reader),
            AirportSubsectionDataType.TaxiwayPoint or AirportSubsectionDataType.TaxiwayPointP3DV5 => new
                AirportTaxiwayPoint(
                    reader),
            AirportSubsectionDataType.TaxiwayParking or AirportSubsectionDataType.TaxiwayParkingP3DV5
                or AirportSubsectionDataType.TaxiwayParkingFS9 =>
                new AirportTaxiwayParkingRecord(reader, airportType),
            AirportSubsectionDataType.TaxiPath or AirportSubsectionDataType.TaxiPathP3DV4
                or AirportSubsectionDataType.TaxiPathP3DV5 => new AirportTaxiPathRecord(reader),
            AirportSubsectionDataType.TaxiName => new AirportTaxiNameRecord(reader),
            AirportSubsectionDataType.Jetway => new AirportJetwayRecord(reader),
            AirportSubsectionDataType.Approach => new AirportApproachRecord(reader),
            AirportSubsectionDataType.Waypoint => new WaypointRecord(reader),
            AirportSubsectionDataType.BlastFence or AirportSubsectionDataType.BoundaryFence =>
                new AirportFenceRecord(reader),
            AirportSubsectionDataType.Polygon => new AirportPolygonRecord(reader),
            _ => null,
        };

    public static BglRecord? Create(AirportApproachDataType approachDataType, BglBinaryReader reader) =>
        approachDataType switch
        {
            AirportApproachDataType.ApproachLegs => new AirportLegBaseRecord(reader),
            AirportApproachDataType.MissedApproachLegs => new AirportLegBaseRecord(reader),
            AirportApproachDataType.Transition => new AirportTransitionRecord(reader),
            _ => null,
        };

    public static BglRecord? Create(AirportRecordDataType airportRecordDataType, BglBinaryReader reader) =>
        airportRecordDataType switch
        {
            AirportRecordDataType.OffsetPrimary or AirportRecordDataType.OffsetSecondary => new
                AirportSubReportBaseRecord(reader, AirportSubReportBaseRecord.SubReportBaseType.OffsetThreshold),
            AirportRecordDataType.BlastPadPrimary or AirportRecordDataType.BlastPadSecondary => new
                AirportSubReportBaseRecord(reader, AirportSubReportBaseRecord.SubReportBaseType.BlastPad),
            AirportRecordDataType.OverrunPrimary or AirportRecordDataType.OverrunSecondary => new
                AirportSubReportBaseRecord(reader, AirportSubReportBaseRecord.SubReportBaseType.Overrun),
            AirportRecordDataType.VasiLeftPrimary or AirportRecordDataType.VasiLeftSecondary
                or AirportRecordDataType.VasiRightPrimary
                or AirportRecordDataType.VasiRightSecondary => new AirportVasiSubRecord(reader),
            AirportRecordDataType.ApproachLightsPrimary or AirportRecordDataType.ApproachLightsSecondary =>
                new AirportApproachLightsSubRecord(reader),
            AirportRecordDataType.MarkingBias => new AirportMarkingBiasSubReportRecord(reader),
            _ => null,
        };

    public static BglRecord? Create(NavigationDataType navigationDataType, BglBinaryReader reader) =>
        navigationDataType switch
        {
            NavigationDataType.Localizer => new LocalizerRecord(reader),
            NavigationDataType.GlideSlope => new GlideslopeRecord(reader),
            NavigationDataType.Dme => new DmeRecord(reader),
            NavigationDataType.Name => new NameRecord(reader),
            _ => null
        };

    public static SceneryBglRecord? Create(SceneryObjectType sceneryObjectType, BglBinaryReader reader) =>
        sceneryObjectType switch
        {
            SceneryObjectType.TaxiSign
                or SceneryObjectType.TaxiSignFS9
                or SceneryObjectType.TaxiSignP3D => new TaxiSignSceneryRecord(reader),
            SceneryObjectType.LibraryObject
                or SceneryObjectType.LibraryObjectFS9 => new LibrarySceneryRecord(reader),
            _ => null,
        };
}