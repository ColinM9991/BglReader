using System.Numerics;
using System.Runtime.CompilerServices;

namespace BglReader.Generic;

/// <summary>
/// A BGL record contains begins with an id and size.
/// </summary>
/// <typeparam name="T">The size type. Sceneries use a 2 byte size while all other records use 4 bytes</typeparam>
public abstract class BaseBglRecord<T> : BglNode where T
    : IBinaryNumber<T>
{
    internal BaseBglRecord(
        BglBinaryReader reader,
        bool shouldRewindStream = true) : base(reader)
    {
        if (shouldRewindStream)
            reader.Position -= Unsafe.SizeOf<ushort>();

        StartPosition = reader.Position;

        Id = reader.ReadUInt16();
        Size = ReadSize(Reader);
    }

    private static T ReadSize(BglBinaryReader reader)
    {
        if (typeof(T) == typeof(ushort))
            return T.CreateChecked(reader.ReadUInt16());

        return typeof(T) == typeof(uint)
            ? T.CreateChecked(reader.ReadUInt32())
            : throw new InvalidOperationException($"Unsupported size type {typeof(T)}");
    }

    public ushort Id { get; }

    private T Size { get; }

    protected override long EndPosition => StartPosition + long.CreateChecked(Size);

    protected long GetRemainingBytes() => EndPosition - Reader.Position;
}