using Ardalis.SmartEnum;

namespace SharpTLEX.Core;

public class SLink : SmartEnum<SLink, string>, ILinkType
{
    public static readonly SLink Modal = new SLink(nameof(Modal), "MODAL");
    public static readonly SLink Evidential = new SLink(nameof(Evidential), "EVIDENTIAL");
    public static readonly SLink NegativeEvidential = new SLink(nameof(NegativeEvidential), "NEG_EVIDENTIAL");
    public static readonly SLink Factive = new SLink(nameof(Factive), "FACTIVE");
    public static readonly SLink CounterFactive = new SLink(nameof(CounterFactive), "COUNTER_FACTIVE");
    public static readonly SLink Conditional = new SLink(nameof(Conditional), "CONDITIONAL");

    private SLink(string name, string value) : base(name, value)
    {
    }

    public string Tag => nameof(SLink);
}
