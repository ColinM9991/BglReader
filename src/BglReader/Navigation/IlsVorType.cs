namespace BglReader.Navigation;

public enum IlsVorType : byte
{
    VorTerminal = 0x0001,
    VorLow = 0x0002,
    VorHigh = 0x0003,
    ILS = 0x0004,
    VorVot = 0x0005,
}