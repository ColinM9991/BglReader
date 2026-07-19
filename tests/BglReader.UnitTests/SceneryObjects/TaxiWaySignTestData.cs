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
                        Coordinate.FromBgl(203221187, 145095926, 0),
                        LibraryObjectFlags.AboveGroundLevel,
                        0,
                        0,
                        0,
                        ImageComplexity.Normal, Guid.Empty),
                    [
                        new TaxiWaySign(Coordinate.FromBgl(203221187, 145095926, 199500), 0, 0, 90,
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