namespace BglReader;

public record IcaoIdentifier
{
    public IcaoIdentifier(uint value)
    {
        Value = Parse(value);
    }
    
    private string Value { get; }

    public override string ToString() => Value;

    private static string Parse(uint code)
    {
        Span<char> chars = stackalloc char[15];
        var index = chars.Length;

        do
        {
            chars[--index] = ToIcaoChar(code % 38);
            code /= 38;
        }
        while (code > 0);

        return new string(chars[index..].Trim());

        static char ToIcaoChar(uint value) => value switch
        {
            >= 2 and <= 11 => (char)('0' + value - 2),
            >= 12 and <= 37 => (char)('A' + value - 12),
            _ => ' '
        };
    }

    public static explicit operator IcaoIdentifier(uint input) => new(input);
}