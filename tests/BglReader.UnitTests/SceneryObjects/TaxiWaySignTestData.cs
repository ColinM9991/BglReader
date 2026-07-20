using BglReader.Scenery;

namespace BglReader.UnitTests.SceneryObjects;

public static class TaxiWaySignTestData
{
    public static TheoryData<string, ExpectedTaxiSignSceneryRecord[]> TaxiWaySignData => new()
    {
        {
            "KTST_TestAirport.bgl",
            [
                new ExpectedTaxiSignSceneryRecord(new ExpectedLibrarySceneryRecordBase(
                        new Coordinate(Longitude.Quantized(-89.15305000), Latitude.Quantized(41.35280000), new Elevation(0)),
                        LibraryObjectFlags.AboveGroundLevel,
                        0,
                        0,
                        0,
                        ImageComplexity.Normal, Guid.Empty),
                    [
                        new TaxiWaySign(new Coordinate(Longitude.Quantized(-89.15305000), Latitude.Quantized(41.35280000), new Elevation(199.5)), 0, 0, 90,
                            TaxiSignFlags.IsAgl | TaxiSignFlags.ClampPitch | TaxiSignFlags.ClampBank,
                            TaxiSignSize.Size3, TaxiSignJustification.Left, "l[A]d[B\\]m[18-36]")
                    ])
            ]
        }
    };
}

public record ExpectedLibrarySceneryRecordBase(
    Coordinate Coordinates,
    LibraryObjectFlags Flags,
    double Pitch,
    double Bank,
    double Heading,
    ImageComplexity ImageComplexity,
    Guid Instance);

public record ExpectedTaxiSignSceneryRecord(ExpectedLibrarySceneryRecordBase Base, ICollection<TaxiWaySign> Signs);