using Ardalis.SmartEnum;

namespace SharpTLEX.Core;

public class SLinkType : SmartEnum<SLinkType, string>
{
    public static readonly SLinkType Modal = new SLinkType(nameof(Modal), "MODAL");
    public static readonly SLinkType Evidential = new SLinkType(nameof(Evidential), "EVIDENTIAL");
    public static readonly SLinkType NegativeEvidential = new SLinkType(nameof(NegativeEvidential), "NEG_EVIDENTIAL");
    public static readonly SLinkType Factive = new SLinkType(nameof(Factive), "FACTIVE");
    public static readonly SLinkType CounterFactive = new SLinkType(nameof(CounterFactive), "COUNTER_FACTIVE");
    public static readonly SLinkType Conditional = new SLinkType(nameof(Conditional), "CONDITIONAL");

    private SLinkType(string name, string value) : base(name, value)
    {
    }
}
