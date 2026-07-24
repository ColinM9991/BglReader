using BglReader.Attributes;

namespace BglReader.ValueObjects;

[BitField(typeof(byte))]
public partial class LightEdgeFixtureFlags
{
    [Bits(0, 2)]
    public partial EdgeLightFixture LeftEdgeLightFixture { get; }
    
    [Bits(2, 2)]
    public partial EdgeLightFixture RightEdgeLightFixture { get; }
}