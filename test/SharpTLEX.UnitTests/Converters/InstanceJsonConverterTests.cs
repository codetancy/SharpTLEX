using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using FluentAssertions;
using SharpTLEX.Core;
using Xunit;
using Xunit.Abstractions;

namespace SharpTLEX.UnitTests.Converters;

public class InstanceJsonConverterTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public InstanceJsonConverterTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void SignalJsonConvert_ShouldSerializeObject()
    {
        var signal = new Signal(1, "when");
        var @event = new Event(2, EventClass.Occurrence);
        var instance = new Instance(3, @event, Tense.Past, Aspect.Perfective, PartOfSpeech.Verb) {Signal = signal};
        string expectedJson = @"{""id"":""ei3"",""event"":{""id"":""e2"",""eventClass"":""OCCURRENCE""},""tense"":""PAST"",""aspect"":""PERFECTIVE"",""pos"":""VERB"",""polarity"":""POSITIVE"",""signal"":{""id"":""s1"",""content"":""when""}}";

        string actualJson = JsonSerializer.Serialize(instance,
            new JsonSerializerOptions() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull});

        actualJson.Should().Be(expectedJson);
    }

    [Fact]
    public void SignalJsonConvert_ShouldDeserializeObject()
    {
        string json = @"{""id"":""ei3"",""event"":{""id"":""e2"",""eventClass"":""OCCURRENCE""},""tense"":""PAST"",""aspect"":""PERFECTIVE"",""pos"":""VERB"",""polarity"":""POSITIVE"",""signal"":{""id"":""s1"",""content"":""when""}}";
        var signal = new Signal(1, "when");
        var @event = new Event(2, EventClass.Occurrence);
        var expectedInstance = new Instance(3, @event, Tense.Past, Aspect.Perfective, PartOfSpeech.Verb) {Signal = signal};

        var actualInstance = JsonSerializer.Deserialize<Instance>(json,
            new JsonSerializerOptions() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull});

        actualInstance.Should().Be(expectedInstance);
    }
}
