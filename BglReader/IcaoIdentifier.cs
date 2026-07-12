namespace BglReader;

public struct IcaoIdentifier
{
    private IcaoIdentifier(string identifier)
    {
        Identifier = identifier;
    }

    private string Identifier { get; }

    public override string ToString() => Identifier;

    public static IcaoIdentifier Parse(uint code, bool hasTypeBits = false)
    {
        if (hasTypeBits)
        {
            code >>= 5;
        }

        Span<char> chars = stackalloc char[5];
        var index = chars.Length;

        do
        {
            chars[--index] = ToIcaoChar(code % 38);
            code /= 38;
        }
        while (code > 0);

        return new IcaoIdentifier(new string(chars[index..]));

        static char ToIcaoChar(uint value) => value switch
        {
            0 => ' ',
            >= 2 and <= 11 => (char)('0' + value - 2),
            >= 12 and <= 37 => (char)('A' + value - 12),
            _ => throw new ArgumentOutOfRangeException(nameof(value))
        };
    }

    public static explicit operator IcaoIdentifier(uint input) => Parse(input);
}