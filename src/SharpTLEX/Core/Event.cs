using System.Text.Json.Serialization;
using Ardalis.SmartEnum.SystemTextJson;
using SharpTLEX.Converters;

namespace SharpTLEX.Core;

public record Event(
    [property: JsonPropertyName("id"), JsonPropertyOrder(0), JsonConverter(typeof(EventIdJsonConverter))]
    int Id,
    [property: JsonPropertyName("eventClass"), JsonPropertyOrder(1), JsonConverter(typeof(SmartEnumValueConverter<EventClass, string>))]
    EventClass EventClass)
{
    [property: JsonPropertyName("stem"), JsonPropertyOrder(2)]
    public string? Stem { get; init; }

    [JsonIgnore]
    public string StrId => "e" + Id;
}
