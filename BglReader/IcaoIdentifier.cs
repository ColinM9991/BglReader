namespace BglReader;

public class IcaoIdentifier(uint value)
{
    private string Value { get; } = Parse(value);

    public override string ToString() => Value;

    private static string Parse(uint code)
    {
        Span<char> chars = stackalloc char[5];
        var index = chars.Length;

        do
        {
            chars[--index] = ToIcaoChar(code % 38);
            code /= 38;
        }
        while (code > 0);

        return new string(chars[index..]);

        static char ToIcaoChar(uint value) => value switch
        {
            0 => ' ',
            >= 2 and <= 11 => (char)('0' + value - 2),
            >= 12 and <= 37 => (char)('A' + value - 12),
            _ => throw new ArgumentOutOfRangeException(nameof(value))
        };
    }

    public static explicit operator IcaoIdentifier(uint input) => new(input);
}