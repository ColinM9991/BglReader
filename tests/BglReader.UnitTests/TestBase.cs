namespace BglReader.UnitTests;

public abstract class TestBase
{
    protected const string FileName = "KTST_TestAirport_v5.bgl";
    
    protected static BglFile GetBglFile(string fileName)
    {
        return new BglFile(File.OpenRead(Path.Combine("TestData", fileName)));
    }
}