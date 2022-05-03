using Ardalis.SmartEnum;

namespace SharpTLEX.Core;

public class Aspect : SmartEnum<Aspect, string>
{
    public static readonly Aspect Progressive = new Aspect(nameof(Progressive), "PROGRESSIVE");
    public static readonly Aspect Perfective = new Aspect(nameof(Perfective), "PERFECTIVE");
    public static readonly Aspect PerfectiveProgressive =
        new Aspect(nameof(PerfectiveProgressive), "PERFECTIVE_PROGRESSIVE");
    public static readonly Aspect None = new Aspect(nameof(None), "NONE");

    private Aspect(string name, string value) : base(name, value)
    {
    }
}
