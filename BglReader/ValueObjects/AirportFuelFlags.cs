using BglReader.Attributes;

namespace BglReader.ValueObjects;

[BitField(typeof(uint))]
public partial class AirportFuelFlags
{
    [Bits(0, 2)]
    public partial FuelAvailability Avgas73Availability { get; }

    [Bits(2, 2)]
    public partial FuelAvailability Avgas87Availability { get; }

    [Bits(4, 2)]
    public partial FuelAvailability Avgas100Availability { get; }

    [Bits(6, 2)]
    public partial FuelAvailability Avgas130Availability { get; }

    [Bits(8, 2)]
    public partial FuelAvailability Avgas145Availability { get; }

    [Bits(10, 2)]
    public partial FuelAvailability MogasAvailability { get; }

    [Bits(12, 2)]
    public partial FuelAvailability JetAvailability { get; }

    [Bits(14, 2)]
    public partial FuelAvailability JetaAvailability { get; }

    [Bits(16, 2)]
    public partial FuelAvailability Jeta1Availability { get; }

    [Bits(18, 2)]
    public partial FuelAvailability JetApAvailability { get; }

    [Bits(20, 2)]
    public partial FuelAvailability JetBAvailability { get; }

    [Bits(22, 2)]
    public partial FuelAvailability Jet4Availability { get; }

    [Bits(24, 2)]
    public partial FuelAvailability UnknownFuelAvailability { get; }

    [Bits(30, 1)]
    public partial bool IsAvgasAvailable { get; }

    [Bits(31, 1)]
    public partial bool IsJetFuelAvailable { get; }
}