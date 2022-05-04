using System.Text.Json;
using System.Text.Json.Serialization;

namespace SharpTLEX.Converters;

public class LinkIdJsonConverter : JsonConverter<int>
{
    public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var match = TimeMLRegex.LinkIdRegex.Match(reader.GetString()!);

        if (!match.Success)
            throw new JsonException($"Property value does not match format {TimeMLRegex.LinkIdRegex}.");

        var span = match.ValueSpan;

        return int.Parse(span[1..]);
    }

    public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
    {
        writer.WriteStringValue($"l{value}");
    }
}
