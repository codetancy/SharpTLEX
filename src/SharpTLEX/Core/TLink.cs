using Ardalis.SmartEnum;

namespace SharpTLEX.Core;

public class TLink : SmartEnum<TLink, string>, ILinkType
{
    public static readonly TLink Before = new TLink(nameof(Before), "BEFORE");
    public static readonly TLink After = new TLink(nameof(After), "AFTER");
    public static readonly TLink Includes = new TLink(nameof(Includes), "INCLUDES");
    public static readonly TLink IsIncluded = new TLink(nameof(IsIncluded), "IS_INCLUDED");
    public static readonly TLink During = new TLink(nameof(During), "DURING");
    public static readonly TLink InverseDuring = new TLink(nameof(InverseDuring), "DURING_INV");
    public static readonly TLink Simultaneous = new TLink(nameof(Simultaneous), "SIMULTANEOUS");
    public static readonly TLink ImmediatelyAfter = new TLink(nameof(ImmediatelyAfter), "IAFTER");
    public static readonly TLink ImmediatelyBefore = new TLink(nameof(ImmediatelyBefore), "IBEFORE");
    public static readonly TLink Identity = new TLink(nameof(Identity), "IDENTITY");
    public static readonly TLink Begins = new TLink(nameof(Begins), "BEGINS");
    public static readonly TLink Ends = new TLink(nameof(Ends), "ENDS");
    public static readonly TLink BegunBy = new TLink(nameof(BegunBy), "BEGUN_BY");
    public static readonly TLink EndedBy = new TLink(nameof(EndedBy), "ENDED_BY");

    private TLink(string name, string value) : base(name, value)
    {
    }

    public string Tag => nameof(TLink);
}
