using BglReader.Airport.Subsections.RunwayDetails;

namespace BglReader.Airport.Subsections.Types;

[BinarySerializable]
public readonly partial struct DeleteStart
{
    [Binary(1)]
    public byte RunwayNumber { get; }

    [Binary(2)]
    public RunwayDesignator RunwayDesignator { get; }

    [Binary(3)]
    public StartType StartType { get; }
    
    [Binary(4)]
    public byte Unknown { get; }
}