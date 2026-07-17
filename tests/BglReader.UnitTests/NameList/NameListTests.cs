using BglReader.NameList;

namespace BglReader.UnitTests.NameList;

public class NameListTests : TestBase
{
    [Theory]
    [MemberData(nameof(NameListTestData.NameListsData), MemberType = typeof(NameListTestData))]
    public void NameList_Parsed(string fileName, Dictionary<NameListItemType, string[]> expectedNames)
    {
        var nameLists = GetBglFile(fileName).GetNameLists();
        
        nameLists.Should().NotBeNull();

        nameLists.Names.Should().BeEquivalentTo(expectedNames);
    }
}