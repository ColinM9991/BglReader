using BglReader.Airport.Subsections.RunwayDetails;
using BglReader.Generic;

namespace BglReader.Navigation;

public class LocalizerRecord : BglRecord
{
    public LocalizerRecord(ushort id, BglBinaryReader reader) : base(id, reader)
    {
        RunwayNumber = reader.ReadByte();
        Designator = (RunwayDesignator)reader.ReadByte();

        Heading = reader.ReadSingle();
        BeamWidthDegrees = reader.ReadSingle();
    }
    
    public byte RunwayNumber { get; }
    
    public RunwayDesignator Designator { get; }
    
    public float Heading { get; }
    
    public float BeamWidthDegrees { get; }
}