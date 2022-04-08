using Ardalis.SmartEnum;

namespace SharpTLEX.Core;

public class TLink : SmartEnum<TLink>, ILinkType
{
    public static readonly TLink Before = new TLink(nameof(Before), 0);
    public static readonly TLink After = new TLink(nameof(After), 1);
    public static readonly TLink Includes = new TLink(nameof(Includes), 2);
    public static readonly TLink IsIncluded = new TLink(nameof(IsIncluded), 3);
    public static readonly TLink During = new TLink(nameof(During), 4);
    public static readonly TLink InverseDuring = new TLink(nameof(InverseDuring), 5);
    public static readonly TLink Simultaneous = new TLink(nameof(Simultaneous), 6);
    public static readonly TLink ImmediatelyAfter = new TLink(nameof(ImmediatelyAfter), 7);
    public static readonly TLink Identity = new TLink(nameof(Identity), 8);
    public static readonly TLink Begins = new TLink(nameof(Begins), 9);
    public static readonly TLink Ends = new TLink(nameof(Ends), 10);
    public static readonly TLink BegunBy = new TLink(nameof(BegunBy), 11);
    public static readonly TLink EndedBy = new TLink(nameof(EndedBy), 12);

    private TLink(string name, int value) : base(name, value)
    {
    }

    public Type Type => typeof(TLink);
}
