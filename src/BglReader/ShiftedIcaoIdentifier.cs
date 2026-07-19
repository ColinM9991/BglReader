namespace BglReader;

public record ShiftedIcaoIdentifier : IcaoIdentifier
{
    public ShiftedIcaoIdentifier(uint value) : base(value >> 5)
    {
    }

    public override string ToString() => base.ToString();

    public static explicit operator ShiftedIcaoIdentifier(uint input) => new(input);
}