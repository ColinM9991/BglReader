using BglReader.Airport.Subsections.RunwayDetails;
using BglReader.Generic;

namespace BglReader.Navigation;

[BinarySerializable]
public partial class LocalizerRecord : BglRecord
{
    [Binary(1)]
    public byte RunwayNumber { get; }
    
    [Binary(2)]
    public RunwayDesignator Designator { get; }
    
    [Binary(3)]
    public float Heading { get; }
    
    [Binary(4)]
    public float BeamWidthDegrees { get; }
}