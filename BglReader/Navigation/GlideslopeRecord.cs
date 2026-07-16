using BglReader.Generic;

namespace BglReader.Navigation;

public class GlideslopeRecord : BglRecord
{
    public GlideslopeRecord(BinaryReader reader) : base(reader)
    {
        Coordinates = Coordinate.FromBgl(
            reader.ReadInt32(),
            reader.ReadInt32(),
            reader.ReadInt32());

        Range = reader.ReadSingle();
        Pitch = reader.ReadSingle();
    }

    public Coordinate Coordinates { get; }

    public float Range { get; }

    public float Pitch { get; }
}