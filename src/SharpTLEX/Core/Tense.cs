using Ardalis.SmartEnum;

namespace SharpTLEX.Core;

public class Tense : SmartEnum<Tense, string>
{
    public static readonly Tense Past = new Tense(nameof(Past), "PAST");
    public static readonly Tense Present = new Tense(nameof(Present), "PRESENT");
    public static readonly Tense Future = new Tense(nameof(Future), "FUTURE");
    public static readonly Tense Infinitive = new Tense(nameof(Infinitive), "INFINITIVE");
    public static readonly Tense Prespart = new Tense(nameof(Prespart), "PRESPART");
    public static readonly Tense Pastpart = new Tense(nameof(Pastpart), "PASPART");
    public static readonly Tense None = new Tense(nameof(None), "NONE");

    private Tense(string name, string value) : base(name, value)
    {
    }
}
