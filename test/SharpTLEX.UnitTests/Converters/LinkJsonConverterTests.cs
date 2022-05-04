using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using FluentAssertions;
using SharpTLEX.Core;
using Xunit;
using Xunit.Abstractions;

namespace SharpTLEX.UnitTests.Converters;

public class LinkJsonConverterTests
{
    private readonly ITestOutputHelper _testOutputHelper;

    public LinkJsonConverterTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void LinkJsonConverter_ShouldSerializeObject()
    {
        var e3 = new Event(3, EventClass.State) {Stem = "own"};
        var ei156 = new Instance(156, e3, Tense.Present, Aspect.None, PartOfSpeech.Verb) {Polarity = Polarity.Negative};
        var t39 = new Timex(39, TimexType.Date, "1989-11-01", "11/01/89")
        {
            TemporalFunction = false, FunctionInDocument = FunctionInDocument.CreationTime
        };
        var s40 = new Signal(40, "already");
        var l4 = new Link(ei156, t39, TLinkType.Includes) {Id = 4, Signal = s40};
        const string expectedJson =
            @"{""id"":""l4"",""from"":{""id"":""ei156"",""event"":{""id"":""e3"",""eventClass"":""STATE"",""stem"":""own""},""tense"":""PRESENT"",""aspect"":""NONE"",""pos"":""VERB"",""polarity"":""NEGATIVE""},""to"":{""id"":""t39"",""type"":""DATE"",""value"":""1989-11-01"",""temporalFunction"":false,""phrase"":""11/01/89"",""functionInDocument"":""CREATION_TIME""},""relType"":""INCLUDES"",""signal"":{""id"":""s40"",""content"":""already""}}";

        string actualJson = JsonSerializer.Serialize(l4,
            new JsonSerializerOptions() {DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull});

        actualJson.Should().Be(expectedJson);
    }

    [Fact]
    public void LinkJsonConverter_ShouldDeserializeObject()
    {
        const string json =
            @"{""id"":""l4"",""from"":{""id"":""ei156"",""event"":{""id"":""e3"",""eventClass"":""STATE"",""stem"":""own""},""tense"":""PRESENT"",""aspect"":""NONE"",""pos"":""VERB"",""polarity"":""NEGATIVE""},""to"":{""id"":""t39"",""type"":""DATE"",""value"":""1989-11-01"",""temporalFunction"":false,""phrase"":""11/01/89"",""functionInDocument"":""CREATION_TIME""},""relType"":""INCLUDES"",""signal"":{""id"":""s40"",""content"":""already""}}";

        var e3 = new Event(3, EventClass.State) {Stem = "own"};
        var ei156 = new Instance(156, e3, Tense.Present, Aspect.None, PartOfSpeech.Verb) {Polarity = Polarity.Negative};
        var t39 = new Timex(39, TimexType.Date, "1989-11-01", "11/01/89")
        {
            TemporalFunction = false, FunctionInDocument = FunctionInDocument.CreationTime
        };
        var s40 = new Signal(40, "already");
        var l4 = new Link(ei156, t39, TLinkType.Includes) {Id = 4, Signal = s40};

        var actualLink = JsonSerializer.Deserialize<Link>(json,
            new JsonSerializerOptions() {DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull});

        actualLink.Should().Be(l4);
    }
}
