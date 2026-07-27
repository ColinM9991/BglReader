using System.Numerics;

namespace BglReader.Generic;

/// <summary>
/// A BGL record contains begins with an id and size.
/// </summary>
/// <typeparam name="T">The size type. Sceneries use a 2 byte size while all other records use 4 bytes</typeparam>
public abstract class BaseBglRecord<T> : BglNode where T
    : IBinaryNumber<T>
{
    /// <summary>
    /// Initializes a new instance of <see cref="BaseBglRecord{T}"/>.
    /// </summary>
    /// <param name="id">The record ID.</param>
    /// <param name="reader">The reader.</param>
    /// <remarks>
    /// <para>The ID should be consumed before calling this constructor.</para>
    /// </remarks>
    protected BaseBglRecord(
        ushort id,
        BglBinaryReader reader) : base(reader)
    {
        StartPosition = reader.Position - sizeof(ushort);

        Id = id;
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