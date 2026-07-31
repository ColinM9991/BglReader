namespace BglReader.Types;

public record ShiftedIcaoIdentifier : IcaoIdentifier
{
    internal ShiftedIcaoIdentifier(BglBinaryReader reader)
        : this(reader.ReadUInt32())
    {
    }
    
    public ShiftedIcaoIdentifier(uint value) : base(value >> 5)
    {
    }

    public override string ToString() => base.ToString();

    public static explicit operator ShiftedIcaoIdentifier(uint input) => new(input);
}