using System.Numerics;
using System.Runtime.CompilerServices;

namespace BglReader.Generic;

/// <inheritdoc/>
public class BglRecord : BglRecord<uint>
{
    protected BglRecord(BinaryReader reader, bool shouldRewindStream = true) : base(reader, shouldRewindStream)
    {
    }
}

/// <summary>
/// A BGL record contains begins with an id and size.
/// </summary>
/// <typeparam name="T">The size type. Sceneries use a 2 byte size while all other records use 4 bytes</typeparam>
public abstract class BglRecord<T> : BglNode
    where T : INumber<T>
{
    internal BglRecord(
        BinaryReader reader,
        bool shouldRewindStream = true)
    {
        if (shouldRewindStream)
            reader.BaseStream.Position -= 2L;

        Offset = reader.BaseStream.Position;

        Id = reader.ReadUInt16();

        var headerSize = typeof(T) == typeof(uint)
            ? reader.ReadUInt32()
            : reader.ReadUInt16();

        Size = T.CreateChecked(headerSize);
    }

    protected static readonly int HeaderSize = sizeof(ushort) + Unsafe.SizeOf<T>();
    
    public long Offset { get; }

    public ushort Id { get; }

    public T Size { get; }

    protected long GetRecordStartPosition() => Offset;

    protected long GetRecordEndPosition() => Offset + long.CreateChecked(Size);
}