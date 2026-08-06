using BglReader.Airport;
using BglReader.Airport.Subsections;
using BglReader.Airport.Subsections.Approach;
using BglReader.Airport.Subsections.Apron;
using BglReader.Airport.Subsections.RunwayDetails;
using BglReader.Airport.Subsections.Taxi;
using BglReader.Generic;
using BglReader.Navigation;
using BglReader.Scenery;
using BglReader.Scenery.LibraryObjects;
using BglReader.Scenery.TaxiSigns;

namespace BglReader;

internal static class AirportSubsectionDataFactory
{
    internal static BglRecord? Create(BglRecordContext context, BglBinaryReader reader)
    {
        var type = (AirportSubsectionDataType)context.RecordId;

        return type switch
        {
            AirportSubsectionDataType.Name => new NameRecord((ushort)type, reader),
            AirportSubsectionDataType.TowerSceneryObject => new TowerSceneryObjectRecord((ushort)type, reader),
            AirportSubsectionDataType.HelipadSceneryObject => new HelipadSceneryObjectRecord((ushort)type, reader),
            AirportSubsectionDataType.Runway or AirportSubsectionDataType.RunwayP3DV4 => new
                AirportRunwayRecord((ushort)type, reader),
            AirportSubsectionDataType.Helipad => new HelipadRecord((ushort)type, reader),
            AirportSubsectionDataType.Start => new AirportRunwayStartRecord((ushort)type, reader),
            AirportSubsectionDataType.Com => new AirportComRecord((ushort)type, reader),
            AirportSubsectionDataType.DeleteAirport => new DeleteAirportRecord((ushort)type, reader),
            AirportSubsectionDataType.ApronFirst or AirportSubsectionDataType.ApronFirstP3DV5 => new
                AirportApronRecord((ushort)type,
                    reader),
            AirportSubsectionDataType.ApronSecond or AirportSubsectionDataType.ApronSecondP3DV4
                or AirportSubsectionDataType.ApronSecondP3DV5 => new AirportApronSecondRecord((ushort)type, reader),
            AirportSubsectionDataType.ApronEdgeLights => new AirportApronEdgeLightsRecord((ushort)type, reader),
            AirportSubsectionDataType.TaxiwayPoint or AirportSubsectionDataType.TaxiwayPointP3DV5 => new
                AirportTaxiwayPoint(
                    (ushort)type, reader),
            AirportSubsectionDataType.TaxiwayParking or AirportSubsectionDataType.TaxiwayParkingP3DV5
                or AirportSubsectionDataType.TaxiwayParkingFS9 =>
                new AirportTaxiwayParkingRecord((ushort)type, reader),
            AirportSubsectionDataType.TaxiPath or AirportSubsectionDataType.TaxiPathP3DV4
                or AirportSubsectionDataType.TaxiPathP3DV5 => new AirportTaxiPathRecord((ushort)type, reader),
            AirportSubsectionDataType.TaxiName => new AirportTaxiNameRecord((ushort)type, reader),
            AirportSubsectionDataType.Jetway => new AirportJetwayRecord((ushort)type, reader),
            AirportSubsectionDataType.Approach or AirportSubsectionDataType.ApproachP3DV6 =>
                new AirportApproachRecord((ushort)type, reader),
            AirportSubsectionDataType.Waypoint => new WaypointRecord((ushort)type, reader),
            AirportSubsectionDataType.BlastFence or AirportSubsectionDataType.BoundaryFence =>
                new AirportFenceRecord((ushort)type, reader),
            AirportSubsectionDataType.Polygon => new AirportPolygonRecord((ushort)type, reader),
            AirportSubsectionDataType.VisualModelBinding => new VisualModelBindingRecord(
                (ushort)type, reader),
            _ => null,
        };
    }
}

internal static class ApproachDataFactory
{
    internal static BglRecord? Create(BglRecordContext context, BglBinaryReader reader)
    {
        var approachDataType = (AirportApproachDataType)context.RecordId;
        return approachDataType switch
        {
            AirportApproachDataType.ApproachLegs => new AirportLegBaseRecord((ushort)approachDataType, reader),
            AirportApproachDataType.MissedApproachLegs => new AirportLegBaseRecord((ushort)approachDataType, reader),
            AirportApproachDataType.Transition or AirportApproachDataType.TransitionV6 => new AirportTransitionRecord(
                (ushort)approachDataType, reader),
            _ => null,
        };
    }
}

internal static class RunwayDataFactory
{
    internal static BglRecord? Create(BglRecordContext context, BglBinaryReader reader)
    {
        var airportRecordDataType = (AirportRecordDataType)context.RecordId;
        return airportRecordDataType switch
        {
            AirportRecordDataType.OffsetPrimary or AirportRecordDataType.OffsetSecondary => new
                AirportSubReportBaseRecord((ushort)airportRecordDataType, reader),
            AirportRecordDataType.BlastPadPrimary or AirportRecordDataType.BlastPadSecondary => new
                AirportSubReportBaseRecord((ushort)airportRecordDataType, reader),
            AirportRecordDataType.OverrunPrimary or AirportRecordDataType.OverrunSecondary => new
                AirportSubReportBaseRecord((ushort)airportRecordDataType, reader),
            AirportRecordDataType.VasiLeftPrimary or AirportRecordDataType.VasiLeftSecondary
                or AirportRecordDataType.VasiRightPrimary
                or AirportRecordDataType.VasiRightSecondary => new AirportVasiSubRecord((ushort)airportRecordDataType,
                    reader),
            AirportRecordDataType.ApproachLightsPrimary or AirportRecordDataType.ApproachLightsSecondary =>
                new AirportApproachLightsSubRecord((ushort)airportRecordDataType, reader),
            AirportRecordDataType.MarkingBias => new AirportMarkingBiasSubReportRecord((ushort)airportRecordDataType,
                reader),
            AirportRecordDataType.ApproachLightsBiasPrimary or AirportRecordDataType.ApproachLightsBiasSecondary =>
                new ApproachLightsBiasSubRecord((ushort)airportRecordDataType, reader),
            _ => null,
        };
    }
}

internal static class NavigationDataFactory
{
    internal static BglRecord? Create(BglRecordContext context, BglBinaryReader reader)
    {
        var navigationDataType = (NavigationDataType)context.RecordId;
        return navigationDataType switch
        {
            NavigationDataType.Localizer => new LocalizerRecord((ushort)navigationDataType, reader),
            NavigationDataType.GlideSlope => new GlideslopeRecord((ushort)navigationDataType, reader),
            NavigationDataType.Dme => new DmeRecord((ushort)navigationDataType, reader),
            NavigationDataType.Name => new NameRecord((ushort)navigationDataType, reader),
            _ => null
        };
    }
}

internal static class SceneryBglRecordFactory
{
    internal static SceneryBglRecord? Create(SceneryObjectType sceneryObjectType, BglBinaryReader reader) =>
        sceneryObjectType switch
        {
            SceneryObjectType.TaxiSign
                or SceneryObjectType.TaxiSignFS9
                or SceneryObjectType.TaxiSignP3D
                or SceneryObjectType.TaxiSignP3DV6 => new TaxiSignSceneryRecord((ushort)sceneryObjectType, reader),
            SceneryObjectType.LibraryObject
                or SceneryObjectType.LibraryObjectFS9 => new LibrarySceneryRecord((ushort)sceneryObjectType, reader),
            _ => null,
        };
}