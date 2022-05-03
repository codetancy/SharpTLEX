using System.Text.Json.Serialization;
using Ardalis.SmartEnum.SystemTextJson;
using SharpTLEX.Converters;

namespace SharpTLEX.Core;

public record Instance(
    [property: JsonPropertyName("id"), JsonPropertyOrder(0), JsonConverter(typeof(EventInstanceIdJsonConverter))]
    int Id,
    [property: JsonPropertyName("event"), JsonPropertyOrder(1)]
    Event Event,
    [property: JsonPropertyName("tense"), JsonPropertyOrder(2), JsonConverter(typeof(SmartEnumValueConverter<Tense, string>))]
    Tense Tense,
    [property: JsonPropertyName("aspect"), JsonPropertyOrder(3), JsonConverter(typeof(SmartEnumValueConverter<Aspect, string>))]
    Aspect Aspect,
    [property: JsonPropertyName("pos"), JsonPropertyOrder(4), JsonConverter(typeof(SmartEnumValueConverter<PartOfSpeech, string>))]
    PartOfSpeech PartOfSpeech)
{
    [property: JsonPropertyName("polarity"), JsonPropertyOrder(5), JsonConverter(typeof(SmartEnumValueConverter<Polarity, string>))]
    public Polarity Polarity { get; init; } = Polarity.Positive;

    [property: JsonPropertyName("modality"), JsonPropertyOrder(6)]
    public string? Modality { get; init; }

    [property: JsonPropertyName("cardinality"), JsonPropertyOrder(7)]
    public string? Cardinality { get; init; }

    [property: JsonPropertyName("signal"), JsonPropertyOrder(8)]
    public Signal? Signal { get; init; }
}
