namespace BglReader.UnitTests;

public abstract class TestBase
{
    protected const string FileName = "KTST_TestAirport.BGL";
    
    protected BglFile GetBglFile(string fileName)
    {
        return new BglFile(fileName, File.OpenRead(Path.Combine("TestData", fileName)));
    }
}