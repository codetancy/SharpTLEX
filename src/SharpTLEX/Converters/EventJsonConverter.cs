using System.Text.Json;
using System.Text.Json.Serialization;
using SharpTLEX.Builders;
using SharpTLEX.Core;

namespace SharpTLEX.Converters;

public class EventJsonConverter : JsonConverter<Event>
{
    public override Event? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
            return null;

        if (reader.TokenType != JsonTokenType.StartObject)
            throw new JsonException("First token must be StartObject token.");

        IEventBuilder builder = new EventBuilder();

        while (reader.Read())
        {
            switch (reader.TokenType)
            {
                case JsonTokenType.PropertyName:
                    string? propertyName = reader.GetString();
                    reader.Read();
                    switch (propertyName)
                    {
                        case "id":
                            var match = TimeMLRegex.EventIdRegex.Match(reader.GetString()!);

                            if (!match.Success)
                                throw new JsonException($"Property {propertyName} does not match format {TimeMLRegex.EventIdRegex}.");

                            var span = match.ValueSpan;

                            int id = int.Parse(span[1..]);

                            builder.SetId(id);
                            break;
                        case "eventClass":
                            var eventClass = EventClass.FromValue(reader.GetString()!);

                            builder.SetEventClass(eventClass);
                            break;
                        case "stem":
                            string? stem = reader.GetString();

                            builder.SetStem(stem);
                            break;
                        default:
                            throw new JsonException($"Property {propertyName} is not defined in {nameof(Event)}.");
                    }
                    break;
                case JsonTokenType.EndObject:
                    return builder.Build();
                default:
                    throw new JsonException($"Unexpected token found during deserialization: {reader.TokenType}.");
            }
        }

        throw new JsonException("Unable to deserialize object.");
    }

    public override void Write(Utf8JsonWriter writer, Event value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        writer.WriteString("id", value.StrId);

        writer.WriteString("eventClass", value.EventClass.Value);

        if (value.Stem is not null)
        {
            writer.WriteString("stem", value.Stem);
        }

        writer.WriteEndObject();
    }
}
