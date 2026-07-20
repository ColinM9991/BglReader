using BglReader.Airport;
using BglReader.Navigation;

namespace BglReader.UnitTests.IlsVor;

public static class IlsVorTestData
{
    public static TheoryData<string, string, ExpectedIlsVorData> IlsVorData => new()
    {
        {
            "KTST_TestAirport.bgl",
            "ITST",
            new ExpectedIlsVorData(
                IlsVorType.ILS,
                new Coordinate(Longitude.Quantized(-89.15309158), Latitude.Quantized(41.31184943), new Elevation(199.339)),
                (Frequency)110350000,
                (MagneticVariation)(-3.5f),
                33344.5273f,
                "KTST",
                true,
                false,
                true,
                false,
                false)
        }
    };

    public static TheoryData<string, string, ExpectedGlideSlopeData> GlideSlopeData => new()
    {
        {
            "KTST_TestAirport.bgl",
            "ITST",
            new ExpectedGlideSlopeData(
                new Coordinate(Longitude.Quantized(-89.15309158), Latitude.Quantized(41.35104943), new Elevation(67.665)),
                3.00f,
                37049.477f)
        }
    };

    public static TheoryData<string, string, ExpectedLocalizerData> LocalizerData => new()
    {
        {
            "KTST_TestAirport.bgl",
            "ITST",
            new ExpectedLocalizerData(
                18,
                RunwayDesignator.None,
                179.580000f,
                5.00f)
        }
    };
}