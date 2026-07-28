namespace BglReader.UnitTests.SceneryObjects;

public class TaxiWaySignTests : TestBase
{
    [Theory]
    [MemberData(nameof(TaxiWaySignTestData.TaxiWaySignData), MemberType = typeof(TaxiWaySignTestData))]
    public void TaxiWaySignRecords_Parsed(string fileName, ExpectedTaxiSignSceneryRecord[] expectedRecords)
    {
        var taxiWaySignRecords = GetBglFile(fileName).GetTaxiSignObjectRecords().ToList();

        taxiWaySignRecords.ShouldNotBeNull();
        taxiWaySignRecords.ShouldNotBeEmpty();

        const double tolerance = 0.005;
        foreach (var expectedRecord in expectedRecords)
        {
            taxiWaySignRecords.ShouldContain(x => x.Coordinates.Equals(expectedRecord.Base.Coordinates)
                                                     && x.Flags == expectedRecord.Base.Flags
                                                     && Math.Abs(x.Pitch.Value - expectedRecord.Base.Pitch) < tolerance
                                                     && Math.Abs(x.Bank.Value - expectedRecord.Base.Bank) < tolerance
                                                     && Math.Abs(x.Heading.Value - expectedRecord.Base.Heading) < tolerance
                                                     && x.ImageComplexity == expectedRecord.Base.ImageComplexity
                                                     && x.Instance.Equals(expectedRecord.Base.Instance)
                                                     && x.NumberOfSigns == expectedRecord.Signs.Count);
        }
    }

    [Theory]
    [MemberData(nameof(TaxiWaySignTestData.TaxiWaySignData), MemberType = typeof(TaxiWaySignTestData))]
    public void TaxiWaySigns_Parsed(string fileName, ExpectedTaxiSignSceneryRecord[] expectedRecords)
    {
        var taxiWaySignRecords = GetBglFile(fileName).GetTaxiSignObjectRecords().ToList();

        taxiWaySignRecords.ShouldNotBeNull();
        taxiWaySignRecords.ShouldNotBeEmpty();

        var taxiWaySigns = taxiWaySignRecords.SelectMany(x => x.Signs).ToList();

        const double tolerance = 0.005;
        foreach (var expectedRecord in expectedRecords.SelectMany(x => x.Signs))
        {
            taxiWaySigns.ShouldContain(x =>
                x.Coordinates.Equals(expectedRecord.Coordinates)
                && Math.Abs(x.Pitch.Value - expectedRecord.Pitch.Value) < tolerance
                && Math.Abs(x.Bank.Value - expectedRecord.Bank.Value) < tolerance
                && Math.Abs(x.Heading.Value - expectedRecord.Heading.Value) < tolerance
                && x.Flags == expectedRecord.Flags
                && x.Size == expectedRecord.Size
                && x.Justification == expectedRecord.Justification
                && string.Equals(x.Label, expectedRecord.Label, StringComparison.OrdinalIgnoreCase));
        }
    }
}