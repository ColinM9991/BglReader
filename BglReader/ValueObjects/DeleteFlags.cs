using BglReader.Attributes;

namespace BglReader.ValueObjects;

[BitField(typeof(ushort))]
public partial class DeleteFlags
{
    [Bits(0)]
    public partial bool AllApproaches { get; }
    
    [Bits(1)]
    public partial bool AllApronLights { get; }
    
    [Bits(2)]
    public partial bool AllAprons { get; }
    
    [Bits(3)]
    public partial bool AllFrequencies { get; }
    
    [Bits(4)]
    public partial bool AllHelipads { get; }
    
    [Bits(5)]
    public partial bool AllRunways { get; }
    
    [Bits(6)]
    public partial bool AllStarts { get; }
    
    [Bits(7)]
    public partial bool AllTaxiways { get; }
}