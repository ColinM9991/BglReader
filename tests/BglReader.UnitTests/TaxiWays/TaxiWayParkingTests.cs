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

        taxiWayParking.ShouldNotBeNull();
        
        taxiWayParking.NumberOfParkingRecords.ShouldBe((ushort)expectedTaxiWayParking.Length);
        for (var i = 0; i < expectedTaxiWayParking.Length; i++)
        {
            var expected = expectedTaxiWayParking[i];
            var actual = taxiWayParking.ParkingRecords.ElementAt(i);
            
            actual.Coordinate.Longitude.ShouldBeEquivalentTo(expected.Coordinate.Longitude);
            actual.Coordinate.Latitude.ShouldBeEquivalentTo(expected.Coordinate.Latitude);
            actual.Coordinate.Elevation.ShouldBeEquivalentTo(expected.Coordinate.Elevation);
            actual.Flags.ShouldBeEquivalentTo(expected.Flags);
            actual.Heading.ShouldBeEquivalentTo(expected.Heading);
            actual.Radius.ShouldBeEquivalentTo(expected.Radius);
            actual.TeeOffset.ShouldBeEquivalentTo(expected.TeeOffset);
            actual.TeeOffset2.ShouldBeEquivalentTo(expected.TeeOffset2);
            actual.TeeOffset3.ShouldBeEquivalentTo(expected.TeeOffset3);
            actual.TeeOffset4.ShouldBeEquivalentTo(expected.TeeOffset4);
            actual.AirlineDesignators.ShouldBeEquivalentTo(expected.AirlineDesignators);
        }
    }
}