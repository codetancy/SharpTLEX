using Ardalis.SmartEnum;

namespace SharpTLEX.Core;

public class ALink : SmartEnum<ALink>, ILinkType
{
    public static readonly ALink Initiates = new ALink(nameof(Initiates), 0);
    public static readonly ALink Culminates = new ALink(nameof(Culminates), 1);
    public static readonly ALink Terminates = new ALink(nameof(Terminates), 2);
    public static readonly ALink Reinitiates = new ALink(nameof(Reinitiates), 3);

    private ALink(string name, int value) : base(name, value)
    {
    }

    public Type Type => typeof(ALink);
}
