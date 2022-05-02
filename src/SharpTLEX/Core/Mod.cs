using Ardalis.SmartEnum;

namespace SharpTLEX.Core;

public class Mod : SmartEnum<Mod, string>
{
    public static readonly Mod Before = new Mod(nameof(Before), "BEFORE");
    public static readonly Mod After = new Mod(nameof(After), "AFTER");
    public static readonly Mod OnOrBefore = new Mod(nameof(OnOrBefore), "ON_OR_BEFORE");
    public static readonly Mod OnOrAfter = new Mod(nameof(OnOrAfter), "ON_OR_AFTER");
    public static readonly Mod LessThan = new Mod(nameof(LessThan), "LESS_THAN");
    public static readonly Mod MoreThan = new Mod(nameof(MoreThan), "MORE_THAN");
    public static readonly Mod EqualOrLess = new Mod(nameof(EqualOrLess), "EQUAL_OR_LESS");
    public static readonly Mod EqualOrMore = new Mod(nameof(EqualOrMore), "EQUAL_OR_MORE");
    public static readonly Mod Start = new Mod(nameof(Start), "START");
    public static readonly Mod Mid = new Mod(nameof(Mid), "MID");
    public static readonly Mod End = new Mod(nameof(End), "END");
    public static readonly Mod Approximate = new Mod(nameof(Approximate), "APPROX");

    private Mod(string name, string value) : base(name, value)
    {
    }
}
