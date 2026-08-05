using BglReader.ValueObjects.BitFields;

namespace BglReader.Airport.Subsections.Approach;

[BinarySerializable]
public partial class ApproachLeg
{
    [Binary(1)]
    public byte Id { get; }

    [Binary(2)]
    public byte AltitudeDescriptor { get; }

    [Binary(3)]
    public ApproachLegFlags Flags { get; }

    [Binary(4)]
    public FixFlags FixFlags { get; }

    [Binary(5)]
    public RegionIdentifierFlags IcaoFlags { get; }

    [Binary(6)]
    public FixFlags RecommendedIdentFlags { get; }

    [Binary(7)]
    public RegionIdentifierFlags RecommendedAirportFlags { get; }

    [Binary(8)]
    public float Theta { get; }

    [Binary(9)]
    public float Rho { get; }

    [Binary(10)]
    public float Course { get; }

    [Binary(11)]
    public float DistanceTime { get; }

    [Binary(12)]
    public float Altitude1 { get; }

    [Binary(13)]
    public float Altitude2 { get; }
}