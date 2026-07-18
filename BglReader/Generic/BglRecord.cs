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
    where T : IBinaryInteger<T>
{
    internal BglRecord(
        BinaryReader reader,
        bool shouldRewindStream = true)
    {
        if (shouldRewindStream)
            reader.BaseStream.Position -= Unsafe.SizeOf<ushort>();

        Offset = reader.BaseStream.Position;

        Id = reader.ReadUInt16();
        Size = ReadSize(reader);
    }

    private static T ReadSize(BinaryReader reader)
    {
        if (typeof(T) == typeof(uint))
            return T.CreateChecked(reader.ReadUInt32());

        return typeof(T) == typeof(ushort)
            ? T.CreateChecked(reader.ReadUInt16())
            : throw new NotSupportedException($"Unsupported BGL record size type {typeof(T)}.");
    }
    
    public long Offset { get; }

    public ushort Id { get; }

    public T Size { get; }

    protected long GetRecordStartPosition() => Offset;

    protected long GetRecordEndPosition() => Offset + long.CreateChecked(Size);

    protected byte[] Consume(BinaryReader reader) => reader
        .ReadBytes((int)(GetRecordEndPosition() - reader.BaseStream.Position))
        .TakeWhile(x => x != 0).ToArray();
}