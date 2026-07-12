namespace BglReader;

public class ShiftedIcaoIdentifier(uint value) : IcaoIdentifier(value >> 5)
{
    public static explicit operator ShiftedIcaoIdentifier(uint input) => new(input);
}