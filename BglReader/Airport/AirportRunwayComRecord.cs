using System.Text;
using BglReader.Generic;

namespace BglReader.Airport;

public class AirportRunwayComRecord : BglRecord
{
    public AirportRunwayComRecord(
        BinaryReader reader) : base(reader)
    {
        Type = reader.ReadUInt16();
        Frequency = reader.ReadUInt32() / 1000;
        Name = Encoding.UTF8.GetString(
            reader.ReadBytes((int)(GetRecordStartPosition() + Size - reader.BaseStream.Position)));
    }

    public ushort Type { get; }

    public uint Frequency { get; }

    public string Name { get; }
}