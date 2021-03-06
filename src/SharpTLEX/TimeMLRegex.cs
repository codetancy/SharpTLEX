using System.Text.RegularExpressions;

namespace SharpTLEX;

public static class TimeMLRegex
{
    public static Regex EventIdRegex = new Regex("^e\\d+$", RegexOptions.Compiled);

    public static Regex SignalIdRegex = new Regex("^s\\d+$", RegexOptions.Compiled);

    public static Regex TimexIdRegex = new Regex("^t\\d+$", RegexOptions.Compiled);

    public static Regex EventInstanceIdRegex = new Regex("^ei\\d+$", RegexOptions.Compiled);

    public static Regex LinkIdRegex = new Regex("^l\\d+$", RegexOptions.Compiled);
}
