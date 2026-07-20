namespace BglReader.UnitTests;

public class QmidTests
{
    [Fact]
    public void Qmid_AsExpected()
    {
        var expectedQmid = new Qmid(1819, 1012, 13);
        var qmid = new Qmid(0x81FAB65);

        qmid.L.ShouldBeEquivalentTo(expectedQmid.L);
        qmid.U.ShouldBeEquivalentTo(expectedQmid.U);
        qmid.V.ShouldBeEquivalentTo(expectedQmid.V);
    }
}