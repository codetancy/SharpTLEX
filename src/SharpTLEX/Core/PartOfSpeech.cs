using Ardalis.SmartEnum;

namespace SharpTLEX.Core;

public class PartOfSpeech : SmartEnum<PartOfSpeech, string>
{
    public static readonly PartOfSpeech Adjective = new PartOfSpeech(nameof(Adjective), "ADJECTIVE");
    public static readonly PartOfSpeech Noun = new PartOfSpeech(nameof(Noun), "NOUN");
    public static readonly PartOfSpeech Verb = new PartOfSpeech(nameof(Verb), "VERB");
    public static readonly PartOfSpeech Preposition = new PartOfSpeech(nameof(Preposition), "PREPOSITION");
    public static readonly PartOfSpeech Other = new PartOfSpeech(nameof(Other), "OTHER");

    private PartOfSpeech(string name, string value) : base(name, value)
    {
    }
}
