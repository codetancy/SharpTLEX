using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using FluentAssertions;
using SharpTLEX.Core;
using Xunit;

namespace SharpTLEX.UnitTests.Converters;

public class EventJsonConverterTests
{
    [Theory]
    [InlineData(1, "REPORTING", "e32", "{\"id\":\"e1\",\"eventClass\":\"REPORTING\",\"stem\":\"e32\"}")]
    [InlineData(1, "REPORTING", null, "{\"id\":\"e1\",\"eventClass\":\"REPORTING\"}")]
    public void EventJsonConvert_ShouldSerializeObject(int id, string eventClass, string? stem, string json)
    {
        var someEvent = new Event(id, EventClass.FromValue(eventClass)) {Stem = stem};

        string actual = JsonSerializer.Serialize(someEvent,
            new JsonSerializerOptions {DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull});

        json.Should().Be(actual);
    }

    [Theory]
    [InlineData(1, "REPORTING", "e32", "{\"id\":\"e1\",\"eventClass\":\"REPORTING\",\"stem\":\"e32\"}")]
    [InlineData(1, "REPORTING", null, "{\"id\":\"e1\",\"eventClass\":\"REPORTING\"}")]
    public void EventJsonConvert_ShouldDeserializeObject(int id, string eventClass, string? stem, string json)
    {
        var expected = new Event(id, EventClass.FromValue(eventClass)) {Stem = stem};

        var actual = JsonSerializer.Deserialize<Event>(json,
            new JsonSerializerOptions {DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull});

        expected.Should().Be(actual);
    }

    [Fact]
    public void EventJsonConvert_ShouldReturnNull_WhenDeserializingNullJson()
    {
        string json = "null";

        var actual = JsonSerializer.Deserialize<Event>(json,
            new JsonSerializerOptions {DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull});

        actual.Should().Be(null);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("42")]
    [InlineData("e")]
    [InlineData(" e42 ")]
    [InlineData("e-42")]
    public void EventJsonConvert_ShouldThrowException_WhenEventIdDoesNotMatchFormat(string eventId)
    {
        string json = $"{{\"id\":\"{eventId}\",\"eventClass\":\"REPORTING\",\"stem\":\"e32\"}}";

        var action = () => JsonSerializer.Deserialize<Event>(json,
            new JsonSerializerOptions {DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull});

        action.Should().Throw<JsonException>()
            .WithMessage($"Property value does not match format {TimeMLRegex.EventIdRegex}.");
    }

    [Fact]
    public void EventJsonConvert_ShouldThrowException_WhenEventClassIsNotDefined()
    {
        string json = "{\"eventClass\":\"UNDEFINED_CLASS\"}";

        var action = () => JsonSerializer.Deserialize<Event>(json,
            new JsonSerializerOptions {DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull});

        action.Should().Throw<Exception>();
    }
}
