namespace BglReader;

public struct IcaoIdentifier
{
    public IcaoIdentifier(string identifier)
    {
        Identifier = identifier;
    }

    public string Identifier { get; set; }

    public static IcaoIdentifier Parse(uint code, bool shift = false)
    {
        if (shift)
        {
            code >>= 5;
        }

        var chars = new List<char>(5);
        while (code > 37)
        {
            var codedChar = code % 38;

            code = (code - codedChar) / 38;
            chars.Add(ToIcaoChar(codedChar));
        }

        chars.Add(ToIcaoChar(code));

        chars.Reverse();

        return new IcaoIdentifier(string.Join("", chars));

        char ToIcaoChar(uint value)
        {
            return value switch
            {
                0 => ' ',
                > 1 and < 12 => (char)('0' + (value - 2)),
                > 11 and < 38 => (char)('A' + (value - 12)),
                _ => throw new ArgumentException(nameof(value)),
            };
        }
    }
}