using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using FluentAssertions;
using SharpTLEX.Core;
using Xunit;

namespace SharpTLEX.UnitTests.Converters;

public class EventJsonConverterTests
{
    private readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    [Theory]
    [InlineData(1, "REPORTING", "e32", "{\"id\":\"e1\",\"eventClass\":\"REPORTING\",\"stem\":\"e32\"}")]
    [InlineData(1, "REPORTING", null,  "{\"id\":\"e1\",\"eventClass\":\"REPORTING\"}")]
    public void EventJsonConvert_ShouldSerializeObject(int eventId, string eventClass, string? eventStem, string json)
    {
        var someEvent = new Event(eventId, EventClass.FromValue(eventClass), eventStem);

        string actual = JsonSerializer.Serialize(someEvent, _jsonSerializerOptions);

        json.Should().Be(actual);
    }

    [Theory]
    [InlineData(1, "REPORTING", "e32", "{\"id\":\"e1\",\"eventClass\":\"REPORTING\",\"stem\":\"e32\"}")]
    [InlineData(1, "REPORTING", null, "{\"id\":\"e1\",\"eventClass\":\"REPORTING\"}")]
    public void EventJsonConvert_ShouldDeserializeObject(int eventId, string eventClass, string? eventStem, string json)
    {
        var expected = new Event(eventId, EventClass.FromValue(eventClass), eventStem);

        var actual = JsonSerializer.Deserialize<Event>(json, _jsonSerializerOptions);

        expected.Should().Be(actual);
    }

    [Fact]
    public void EventJsonConvert_ShouldReturnNull_WhenDeserializingNullJson()
    {
        string json = "null";

        var actual = JsonSerializer.Deserialize<Event>(json, _jsonSerializerOptions);

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

        var action = () => JsonSerializer.Deserialize<Event>(json, _jsonSerializerOptions);

        action.Should().Throw<JsonException>()
            .WithMessage($"Property id does not match format {TimeMLRegex.EventIdRegex}.");
    }

    [Fact]
    public void EventJsonConvert_ShouldThrowException_WhenPropertyIsNotDefinedInEvent()
    {
        string json = "{\"undefinedProperty\":\"someValue\"}";

        var action = () => JsonSerializer.Deserialize<Event>(json, _jsonSerializerOptions);

        action.Should().Throw<JsonException>()
            .WithMessage($"Property undefinedProperty is not defined in {nameof(Event)}.");
    }

    [Fact]
    public void EventJsonConvert_ShouldThrowException_WhenEventClassIsNotDefined()
    {
        string json = "{\"eventClass\":\"UNDEFINED_CLASS\"}";

        var action = () => JsonSerializer.Deserialize<Event>(json, _jsonSerializerOptions);

        action.Should().Throw<Exception>();
    }

}
