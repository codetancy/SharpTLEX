using System.Text.Json;
using System.Text.Json.Serialization;
using SharpTLEX.Core;

namespace SharpTLEX.Converters;

public class LinkTypeJsonConverter : JsonConverter<LinkType>
{
    public override LinkType? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.TokenType == JsonTokenType.Null ? null : GetFromValue(reader.GetString()!);
    }

    private static LinkType GetFromValue(string value)
    {
        if (TLinkType.TryFromValue(value, out TLinkType tLinkType))
        {
            return tLinkType;
        }
        else if (SLinkType.TryFromValue(value, out SLinkType sLinkType))
        {
            return sLinkType;
        }
        else if (ALinkType.TryFromValue(value, out ALinkType aLinkType))
        {
            return aLinkType;
        }
        else
        {
            throw new JsonException();
        }
    }

    public override void Write(Utf8JsonWriter writer, LinkType value, JsonSerializerOptions options)
    {
        if (value.IsT0)
        {
            writer.WriteStringValue(value.AsT0.Value);
        }
        else if (value.IsT1)
        {
            writer.WriteStringValue(value.AsT1.Value);
        }
        else if (value.IsT2)
        {
            writer.WriteStringValue(value.AsT2.Value);
        }
        else
        {
            throw new JsonException();
        }
    }
}
