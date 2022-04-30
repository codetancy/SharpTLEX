using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using FluentAssertions;
using SharpTLEX.Core;
using Xunit;

namespace SharpTLEX.UnitTests.Converters;

public class SignalJsonConverterTests
{
    [Fact]
    public void SignalJsonConvert_ShouldSerializeObject()
    {
        var signal = new Signal(1, "when");
        string expectedJson = "{\"id\":\"s1\",\"content\":\"when\"}";

        string actualJson = JsonSerializer.Serialize(signal,
            new JsonSerializerOptions(){DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull});

        actualJson.Should().Be(expectedJson);
    }

    [Fact]
    public void SignalJsonConvert_ShouldDeserializeObject()
    {
        string json = "{\"id\":\"s1\",\"content\":\"when\"}";
        var expectedSignal = new Signal(1, "when");

        var actualSignal = JsonSerializer.Deserialize<Signal>(json,
            new JsonSerializerOptions(){DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull});

        actualSignal.Should().Be(expectedSignal);
    }
}
