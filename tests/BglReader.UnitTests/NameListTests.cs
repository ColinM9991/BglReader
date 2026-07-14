using BglReader.NameList;
using FluentAssertions;

namespace BglReader.UnitTests;

public class NameListTests : TestBase
{
    [Fact]
    public void NameList_Parsed()
    {
        var bglFile = GetBglFile(FileName);
        var nameListSection = bglFile.Sections.FirstOrDefault(x => x.Type is SectionType.NameList);
        nameListSection.Should().NotBeNull();
        
        nameListSection.Subsections.Should().HaveCount(nameListSection.SubsectionsCount);

        var nameListSubsection = nameListSection.Subsections.First();
        nameListSubsection.Should().NotBeNull();

        var nameListRecord = nameListSubsection.Data.First() as NameListRecord;
        nameListRecord.Should().NotBeNull();

        nameListRecord.Names.Should().BeEquivalentTo(new Dictionary<NameListItemType, string[]>
        {
            { NameListItemType.Region, new[] { "North America" } },
            { NameListItemType.Country, new[] { "United States" } },
            { NameListItemType.State, new[] { "Illinois" } },
            { NameListItemType.City, new[] { "Testfield" } },
            { NameListItemType.Airport, new[] { "Testfield Regional" } },
        });
    }
}