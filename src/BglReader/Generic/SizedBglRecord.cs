using System.Numerics;

namespace BglReader.Generic;

/// <summary>
/// Represents a sized BGL record.
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class SizedBglRecord<T> : BaseBglRecord where T : IBinaryNumber<T>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SizedBglRecord{T}"/> class with a defined size.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="reader"></param>
    protected SizedBglRecord(ushort id, BglBinaryReader reader) : base(id, reader)
    {
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

    private T Size { get; }

    protected override long EndPosition => StartPosition + long.CreateChecked(Size);

    protected long RemainingBytes => EndPosition - Reader.Position;
    
    protected long GetRemainingBytes() => EndPosition - Reader.Position;
}