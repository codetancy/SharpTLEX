using Ardalis.SmartEnum;

namespace SharpTLEX.Core;

public class ALinkType : SmartEnum<ALinkType, string>
{
    public static readonly ALinkType Initiates = new ALinkType(nameof(Initiates), "INITIATES");
    public static readonly ALinkType Culminates = new ALinkType(nameof(Culminates), "CULMINATES");
    public static readonly ALinkType Terminates = new ALinkType(nameof(Terminates), "TERMINATES");
    public static readonly ALinkType Continues = new ALinkType(nameof(Continues), "CONTINUES");
    public static readonly ALinkType Reinitiates = new ALinkType(nameof(Reinitiates), "REINITIATES");

    private ALinkType(string name, string value) : base(name, value)
    {
    }
}
