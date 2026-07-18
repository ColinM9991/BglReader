using System.Numerics;
using System.Runtime.CompilerServices;

namespace BglReader.Generic;

/// <inheritdoc/>
public class BglRecord : BglRecord<uint>
{
    protected BglRecord(BglBinaryReader reader, bool shouldRewindStream = true) : base(reader, shouldRewindStream)
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
    private readonly BglBinaryReader _reader;
    
    internal BglRecord(
        BglBinaryReader reader,
        bool shouldRewindStream = true)
    {
        _reader = reader;
        
        if (shouldRewindStream)
            reader.Position -= Unsafe.SizeOf<ushort>();

        Offset = reader.Position;

        Id = reader.ReadUInt16();
        Size = ReadSize(reader);
    }

    private static T ReadSize(BglBinaryReader reader)
    {
        if (typeof(T) == typeof(uint))
            return T.CreateChecked(reader.ReadUInt32());

        return typeof(T) == typeof(ushort)
            ? T.CreateChecked(reader.ReadUInt16())
            : throw new NotSupportedException($"Unsupported BGL record size type {typeof(T)}.");
    }
    
    private long Offset { get; }

    public ushort Id { get; }

    public T Size { get; }

    protected long GetRecordStartPosition() => Offset;

    protected long GetRecordEndPosition() => Offset + long.CreateChecked(Size);

    protected long GetRemainingBytes() => GetRecordEndPosition() - _reader.Position;
}