using Ardalis.SmartEnum;

namespace SharpTLEX.Core;

public class ALink : SmartEnum<ALink, string>, ILinkType
{
    public static readonly ALink Initiates = new ALink(nameof(Initiates), "INITIATES");
    public static readonly ALink Culminates = new ALink(nameof(Culminates), "CULMINATES");
    public static readonly ALink Terminates = new ALink(nameof(Terminates), "TERMINATES");
    public static readonly ALink Continues = new ALink(nameof(Continues), "CONTINUES");
    public static readonly ALink Reinitiates = new ALink(nameof(Reinitiates), "REINITIATES");

    private ALink(string name, string value) : base(name, value)
    {
    }

    public string Tag => nameof(ALink);
}
