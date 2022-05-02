using Ardalis.SmartEnum;

namespace SharpTLEX.Core;

public class TimexType : SmartEnum<TimexType, string>
{
    public static readonly TimexType Date = new TimexType(nameof(Date), "DATE");
    public static readonly TimexType Time = new TimexType(nameof(Time), "TIME");
    public static readonly TimexType Duration = new TimexType(nameof(Duration), "DURATION");
    public static readonly TimexType Set = new TimexType(nameof(Set), "SET");

    private TimexType(string name, string value) : base(name, value)
    {
    }
}
