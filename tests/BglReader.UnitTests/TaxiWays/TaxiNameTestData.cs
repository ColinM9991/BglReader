namespace BglReader.UnitTests.TaxiWays;

public static class TaxiNameTestData
{
    public static TheoryData<string, string, string[]> TaxiNameData => new()
    {
        {
            "KTST_TestAirport_v5.bgl",
            "KTST",
            new[] { "A", "B" }
        }
    };
}