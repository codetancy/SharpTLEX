using System.Text.Json.Serialization;
using SharpTLEX.Converters;

namespace SharpTLEX.Core;

public record Link(
    [property: JsonPropertyName("from"), JsonPropertyOrder(1), JsonConverter(typeof(TimexOrInstanceJsonConverter))]
    TimexOrInstance From,
    [property: JsonPropertyName("to"), JsonPropertyOrder(2), JsonConverter(typeof(TimexOrInstanceJsonConverter))]
    TimexOrInstance To,
    [property: JsonPropertyName("relType"), JsonPropertyOrder(3), JsonConverter(typeof(LinkTypeJsonConverter))]
    LinkType Type)
{
    [property: JsonPropertyName("id"), JsonPropertyOrder(0), JsonConverter(typeof(LinkIdJsonConverter))]
    public int? Id { get; init; }

    [property: JsonPropertyName("syntax"), JsonPropertyOrder(4)]
    public string? Syntax { get; init; }

    [property: JsonPropertyName("signal"), JsonPropertyOrder(5)]
    public Signal? Signal { get; init; }

    [property: JsonPropertyName("origin"), JsonPropertyOrder(6)]
    public string? Origin { get; init; }

    [JsonIgnore]
    public string? StrId => Id is null ? null : "l" + Id;
}
