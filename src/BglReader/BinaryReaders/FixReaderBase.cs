using BglReader.Airport.Subsections.Types;
using BglReader.Types;
using BglReader.ValueObjects.BitFields;

namespace BglReader.BinaryReaders;

public abstract class FixReaderBase
{
    protected static (FixType, IcaoIdentifier) V6Read(BglBinaryReader reader) =>
        ((FixType)reader.ReadUInt32(), new IcaoIdentifier(reader.ReadUInt32()));

    protected static (FixType, IcaoIdentifier) PackedRead(BglBinaryReader reader)
    {
        var fixFlags = new FixFlags(reader.ReadUInt32());
        return (fixFlags.Type, fixFlags.Identifier);
    }
}