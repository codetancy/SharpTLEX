using Ardalis.SmartEnum;

namespace SharpTLEX.Core;

public class TLinkType : SmartEnum<TLinkType, string>
{
    public static readonly TLinkType Before = new TLinkType(nameof(Before), "BEFORE");
    public static readonly TLinkType After = new TLinkType(nameof(After), "AFTER");
    public static readonly TLinkType Includes = new TLinkType(nameof(Includes), "INCLUDES");
    public static readonly TLinkType IsIncluded = new TLinkType(nameof(IsIncluded), "IS_INCLUDED");
    public static readonly TLinkType During = new TLinkType(nameof(During), "DURING");
    public static readonly TLinkType InverseDuring = new TLinkType(nameof(InverseDuring), "DURING_INV");
    public static readonly TLinkType Simultaneous = new TLinkType(nameof(Simultaneous), "SIMULTANEOUS");
    public static readonly TLinkType ImmediatelyAfter = new TLinkType(nameof(ImmediatelyAfter), "IAFTER");
    public static readonly TLinkType ImmediatelyBefore = new TLinkType(nameof(ImmediatelyBefore), "IBEFORE");
    public static readonly TLinkType Identity = new TLinkType(nameof(Identity), "IDENTITY");
    public static readonly TLinkType Begins = new TLinkType(nameof(Begins), "BEGINS");
    public static readonly TLinkType Ends = new TLinkType(nameof(Ends), "ENDS");
    public static readonly TLinkType BegunBy = new TLinkType(nameof(BegunBy), "BEGUN_BY");
    public static readonly TLinkType EndedBy = new TLinkType(nameof(EndedBy), "ENDED_BY");

    private TLinkType(string name, string value) : base(name, value)
    {
    }

}
