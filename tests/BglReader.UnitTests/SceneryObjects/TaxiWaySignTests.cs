namespace BglReader.UnitTests.SceneryObjects;

public class TaxiWaySignTests : TestBase
{
    [Theory]
    [MemberData(nameof(TaxiWaySignTestData.TaxiWaySignData), MemberType = typeof(TaxiWaySignTestData))]
    public void TaxiWaySignRecords_Parsed(string fileName, ExpectedTaxiSignSceneryRecord[] expectedRecords)
    {
        var taxiWaySignRecords = GetBglFile(fileName).GetTaxiSignObjectRecords().ToList();

        taxiWaySignRecords.Should().NotBeNull();
        taxiWaySignRecords.Should().NotBeEmpty();

        const double tolerance = 0.005;
        foreach (var expectedRecord in expectedRecords)
        {
            taxiWaySignRecords.Should().Contain(x => x.Coordinates.Equals(expectedRecord.Base.Coordinates)
                                                     && x.Flags == expectedRecord.Base.Flags
                                                     && Math.Abs(x.Pitch - expectedRecord.Base.Pitch) < tolerance
                                                     && Math.Abs(x.Bank - expectedRecord.Base.Bank) < tolerance
                                                     && Math.Abs(x.Heading - expectedRecord.Base.Heading) < tolerance
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

        taxiWaySignRecords.Should().NotBeNull();
        taxiWaySignRecords.Should().NotBeEmpty();

        var taxiWaySigns = taxiWaySignRecords.SelectMany(x => x.Signs).ToList();

        foreach (var expectedRecord in expectedRecords.SelectMany(x => x.Signs))
        {
            taxiWaySigns.Should().Contain(x =>
                x.Coordinates.Equals(expectedRecord.Coordinates)
                && x.Pitch == expectedRecord.Pitch
                && x.Bank == expectedRecord.Bank
                && x.Heading == expectedRecord.Heading
                && x.Flags == expectedRecord.Flags
                && x.Size == expectedRecord.Size
                && x.Justification == expectedRecord.Justification
                && string.Equals(x.Label, expectedRecord.Label, StringComparison.OrdinalIgnoreCase));
        }
    }
}