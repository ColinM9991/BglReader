namespace BglReader.UnitTests;

public class QmidTests
{
    [Fact]
    public void Qmid_AsExpected()
    {
        var expectedQmid = new Qmid(1819, 1012, 13);
        var qmid = new Qmid(0x81FAB65);

        qmid.Should().BeEquivalentTo(expectedQmid);
    }
}