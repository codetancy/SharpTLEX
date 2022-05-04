using System.Text.Json;
using System.Text.Json.Serialization;
using SharpTLEX.Core;

namespace SharpTLEX.Converters;

public class TimexOrInstanceJsonConverter : JsonConverter<TimexOrInstance>
{
    private enum Discriminator
    {
        Timex,
        Instance
    }

    public override TimexOrInstance? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var lookaheadReader = reader;

        if (lookaheadReader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException();
        }

        lookaheadReader.Read();
        if (lookaheadReader.TokenType != JsonTokenType.PropertyName)
        {
            throw new JsonException();
        }

        string? propertyName = lookaheadReader.GetString();
        if (propertyName != "id")
        {
            throw new JsonException();
        }

        lookaheadReader.Read();
        var discriminator = lookaheadReader.GetString() switch
        {
            {} value when TimeMLRegex.TimexIdRegex.IsMatch(value) => Discriminator.Timex,
            {} value when TimeMLRegex.EventInstanceIdRegex.IsMatch(value) => Discriminator.Instance,
            _ => throw new JsonException()
        };

        TimexOrInstance timexOrInstance = discriminator switch
        {
            Discriminator.Timex => JsonSerializer.Deserialize<Timex>(ref reader)!,
            Discriminator.Instance => JsonSerializer.Deserialize<Instance>(ref reader)!,
            _ => throw new JsonException()
        };

        return timexOrInstance;
    }

    public override void Write(Utf8JsonWriter writer, TimexOrInstance value, JsonSerializerOptions options)
    {
        string json = value switch
        {
            {Value: Timex} => JsonSerializer.Serialize(value.AsT0, options),
            {Value: Instance} => JsonSerializer.Serialize(value.AsT1, options),
            _ => throw new JsonException()
        };

        writer.WriteRawValue(json);
    }
}
