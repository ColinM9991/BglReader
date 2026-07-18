using System.Diagnostics;

namespace BglReader.Generic;

/// <summary>
/// A BGL node is the foundation of every BGL entry
/// </summary>
/// <remarks>
/// This type would be used when the BGL item does not contain an ID or Size.
/// </remarks>
public abstract class BglNode(BglBinaryReader reader)
{
    protected BglBinaryReader Reader { get; } = reader;

    protected long StartPosition { get; set; } = reader.Position;

    protected abstract long EndPosition { get; }

    [Conditional("DEBUG")]
    public void AssertEndPosition()
    {
        Debug.Assert(Reader.Position == EndPosition);
    }
}