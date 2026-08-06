using BglReader.Generic;

namespace BglReader.Scenery;

/// <inheritdoc/>
public class SceneryBglRecord : SizedBglRecord<ushort>
{
    protected SceneryBglRecord(ushort id, BglBinaryReader reader) : base(id, reader)
    {
    }

    /// <summary>
    /// Consumes the ID from the reader and returns a new SceneryBglRecord instance.
    /// </summary>
    /// <param name="reader">The reader.</param>
    /// <returns>A <see cref="SceneryBglRecord"/>.</returns>
    public static SceneryBglRecord? Read(BglBinaryReader reader)
    {
        var id = reader.ReadUInt16();

        return Create(id, reader);
    }

    /// <summary>
    /// Creates a new SceneryBglRecord instance from the supplied ID.
    /// </summary>
    /// <param name="id">The record ID.</param>
    /// <param name="reader">The reader.</param>
    /// <returns>A <see cref="SceneryBglRecord"/>.</returns>
    public static SceneryBglRecord? Create(ushort id, BglBinaryReader reader)
    {
        var sceneryType = (SceneryObjectType)id;
        
        return SceneryBglRecordFactory.Create(sceneryType, reader);
    }
}