using BglReader.Airport.Taxi;

namespace BglReader.UnitTests.TaxiWays;

public class TaxiWayNameTests : TestBase
{
    [Theory]
    [MemberData(nameof(TaxiNameTestData.TaxiNameData), MemberType = typeof(TaxiNameTestData))]
    public void TaxiName_Parsed(string fileName, string identifier, string[] expectedNames)
    {
        var taxiNames = GetBglFile(fileName)
            .GetAirport(identifier)
            .GetSubRecordByType<AirportTaxiNameRecord>()
            .Single();
        
        taxiNames.ShouldNotBeNull();
        
        taxiNames.NumberOfRecords.ShouldBe((ushort)expectedNames.Length);
        taxiNames.Records.ShouldBeEquivalentTo(expectedNames.ToList());
    }
}