using System.Text.Json.Serialization;
using SharpTLEX.Converters;

namespace SharpTLEX.Core;

public record Signal(
    [property: JsonPropertyName("id"), JsonPropertyOrder(0), JsonConverter(typeof(SignalIdJsonConverter))]
    int Id,
    [property: JsonPropertyName("content"), JsonPropertyOrder(1)]
    string Content)
{
    [JsonIgnore]
    public string StrId => "s" + Id;
}
