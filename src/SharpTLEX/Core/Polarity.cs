using Ardalis.SmartEnum;

namespace SharpTLEX.Core;

public class Polarity : SmartEnum<Polarity, string>
{
    public static readonly Polarity Positive = new Polarity(nameof(Positive), "POSITIVE");
    public static readonly Polarity Negative = new Polarity(nameof(Negative), "NEGATIVE");

    private Polarity(string name, string value) : base(name, value)
    {
    }
}
