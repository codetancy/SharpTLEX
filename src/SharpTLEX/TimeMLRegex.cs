using System.Text.RegularExpressions;

namespace SharpTLEX;

public static class TimeMLRegex
{
    public static Regex EventIdRegex = new Regex("^e\\d+$", RegexOptions.Compiled);
}
