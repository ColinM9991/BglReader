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
        
        taxiNames.Should().NotBeNull();
        
        taxiNames.NumberOfRecords.Should().Be((ushort)expectedNames.Length);
        taxiNames.Records.Should().BeEquivalentTo(expectedNames);
    }
}