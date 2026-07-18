using BglReader.Generic;

namespace BglReader.Navigation;

public class GlideslopeRecord : BglRecord
{
    public GlideslopeRecord(BglBinaryReader reader) : base(reader)
    {
        _ = reader.ReadBytes(2); // TODO Unknown
        Coordinates = reader.ReadCoordinates();

        Range = reader.ReadSingle();
        Pitch = reader.ReadSingle();
    }

    public Coordinate Coordinates { get; }

    public float Range { get; }

    public float Pitch { get; }
}