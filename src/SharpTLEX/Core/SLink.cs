using Ardalis.SmartEnum;

namespace SharpTLEX.Core;

public class SLink : SmartEnum<SLink>, ILinkType
{
    public static readonly SLink Modal = new SLink(nameof(Modal), 0);
    public static readonly SLink Evidential = new SLink(nameof(Evidential), 1);
    public static readonly SLink NegativeEvidential = new SLink(nameof(NegativeEvidential), 2);
    public static readonly SLink Factive = new SLink(nameof(Factive), 3);
    public static readonly SLink CounterFactive = new SLink(nameof(CounterFactive), 4);

    private SLink(string name, int value) : base(name, value)
    {
        int some = value;
    }

    public Type Type => typeof(SLink);
}
