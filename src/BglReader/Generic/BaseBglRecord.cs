namespace BglReader.Generic;

/// <summary>
/// Represents the basis of a BGL record which contains an ID.
/// </summary>
public abstract class BaseBglRecord : BglNode
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
    }
    
    public ushort Id { get; }
}