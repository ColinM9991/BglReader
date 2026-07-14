using System.Text;
using BglReader.Generic;

namespace BglReader.Airport;

public class AirportComRecord : BglRecord
{
    public AirportComRecord(
        BinaryReader reader) : base(reader)
    {
        // P3D uses 2 bytes for the Type.
        // While the legacy types begin at 0x0001 (ATIS), P3Dv5 adds 0x0700 (0x0701 being ATIS)
        // Duplication across types can be avoided by taking the first byte and discarding the second, otherwise the enum would require definitions for 0x0001 and 0x0701
        Type = (ComType)reader.ReadByte();
        _ = reader.ReadByte();
        
        Frequency = (Frequency)reader.ReadUInt32();
        Name = Encoding.UTF8.GetString(
            Consume(reader)); // TODO Validate whether Name bytes can be non-existent
    }

    public ComType Type { get; }

    public Frequency Frequency { get; }

    public string Name { get; }
}