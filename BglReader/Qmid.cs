namespace BglReader;

public struct Qmid
{
    public Qmid(uint value)
    {
        (U, V, L) = CalculateQmid(value, 0);
    }

    public int L { get; }

    public int U { get; }

    public int V { get; }

    private static (int U, int V, int L) CalculateQmid(uint dwordA, uint dwordB)
    {
        var v = 0;
        var u = 0;
        var cnt = 0x1F;
        var workDwordA = dwordA;
        var workDwordB = dwordB;

        while (cnt > 0 && (workDwordB & 0x80000000) == 0)
        {
            workDwordB <<= 2;
            workDwordB += (workDwordA & 0xC0000000) >> 30;

            workDwordA += workDwordA;
            workDwordA += workDwordA;
            cnt--;
        }

        workDwordB &= 0x7FFFFFFF;
        var level = cnt;

        while (cnt >= 0)
        {
            if ((workDwordB & 0x80000000) != 0)
            {
                v += (1 << cnt);
            }

            if ((workDwordB & 0x40000000) != 0)
            {
                u += (1 << cnt);
            }

            workDwordB <<= 2;
            workDwordB += (workDwordA & 0xC0000000) >> 30;
            workDwordA += workDwordA;
            workDwordA += workDwordA;
            cnt--;
        }

        return (u, v, level);
    }
};