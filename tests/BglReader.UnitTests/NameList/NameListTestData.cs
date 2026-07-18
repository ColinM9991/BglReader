using BglReader.NameList;

namespace BglReader.UnitTests.NameList;

public static class NameListTestData
{
    public static TheoryData<string, Dictionary<NameListItemType, string[]>> NameListsData =>
        new()
        {
            {
                "KTST_TestAirport.bgl", new Dictionary<NameListItemType, string[]>
                {
                    { NameListItemType.Region, new[] { "North America" } },
                    { NameListItemType.Country, new[] { "United States" } },
                    { NameListItemType.State, new[] { "Illinois" } },
                    { NameListItemType.City, new[] { "Testfield" } },
                    { NameListItemType.Airport, new[] { "Testfield Regional" } },
                }
            }
        };
}