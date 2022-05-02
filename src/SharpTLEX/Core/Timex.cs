using System.Text.Json.Serialization;
using Ardalis.SmartEnum.SystemTextJson;
using SharpTLEX.Converters;

namespace SharpTLEX.Core;

public record Timex(
    [property: JsonPropertyName("id"), JsonPropertyOrder(0), JsonConverter(typeof(TimeIdJsonConverter))]
    int Id,
    [property: JsonPropertyName("type"), JsonPropertyOrder(1), JsonConverter(typeof(SmartEnumValueConverter<TimexType, string>))]
    TimexType Type,
    [property: JsonPropertyName("value"), JsonPropertyOrder(2)]
    string Value,
    [property: JsonPropertyName("temporalFunction"), JsonPropertyOrder(3)]
    bool TemporalFunction,
    [property: JsonPropertyName("phrase"), JsonPropertyOrder(4)]
    string Phrase)
{
    [property: JsonPropertyName("mod"), JsonPropertyOrder(5), JsonConverter(typeof(SmartEnumValueConverter<Mod, string>))]
    public Mod? Mod { get; init; }

    [property: JsonPropertyName("functionInDocument"), JsonPropertyOrder(6), JsonConverter(typeof(SmartEnumValueConverter<FunctionInDocument, string>))]
    public FunctionInDocument? FunctionInDocument { get; init; }

    [property: JsonPropertyName("anchorId"), JsonPropertyOrder(7), JsonConverter(typeof(TimeIdJsonConverter))]
    public int? AnchorTimeId { get; init; }

    [property: JsonPropertyName("beginPoint"), JsonPropertyOrder(8), JsonConverter(typeof(TimeIdJsonConverter))]
    public int? BeginPointId { get; init; }

    [property: JsonPropertyName("endPoint"), JsonPropertyOrder(9), JsonConverter(typeof(TimeIdJsonConverter))]
    public int? EndPointId { get; init; }

    [property: JsonPropertyName("quant"), JsonPropertyOrder(10)]
    public string? Quantification { get; init; }

    [property: JsonPropertyName("freq"), JsonPropertyOrder(11)]
    public string? Frequency { get; init; }

    [JsonIgnore]
    public string StrId => "t" + Id;

    [JsonIgnore]
    public string? AnchorTimeStrId => AnchorTimeId is null ? null : "t" + AnchorTimeId;

    [JsonIgnore]
    public string? BeginPointStrId => BeginPointId is null ? null : "t" + BeginPointId;

    [JsonIgnore]
    public string? EndPointStrId => EndPointId is null ? null : "t" + EndPointId;
}
