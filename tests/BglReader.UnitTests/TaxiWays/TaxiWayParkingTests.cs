using BglReader.Airport.Taxi;

namespace BglReader.UnitTests.TaxiWays;

public class TaxiWayParkingTests : TestBase
{
    [Theory]
    [MemberData(nameof(TaxiWayParkingTestData.TaxiWayParkingData), MemberType = typeof(TaxiWayParkingTestData))]
    public void TaxiWayParking_Parsed(string fileName, string identifier, TaxiParking[] expectedTaxiWayParking)
    {
        var taxiWayParking = GetBglFile(fileName)
            .GetAirport(identifier)
            .GetSubRecordByType<AirportTaxiwayParkingRecord>()
            .Single();

        taxiWayParking.Should().NotBeNull();
        
        taxiWayParking.NumberOfParkingRecords.Should().Be((ushort)expectedTaxiWayParking.Length);
        taxiWayParking.ParkingRecords.Should().BeEquivalentTo(expectedTaxiWayParking);
    }
}