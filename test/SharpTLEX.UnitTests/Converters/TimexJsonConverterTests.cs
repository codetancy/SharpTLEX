using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using FluentAssertions;
using SharpTLEX.Core;
using Xunit;

namespace SharpTLEX.UnitTests.Converters;

public class TimexJsonConverterTests
{
    [Fact]
    public void TimexJsonConvert_ShouldSerializeTimex()
    {
        var timex = new Timex(1, TimexType.Time, "T24:00", "twelve o'clock midnight") {TemporalFunction = false};
        string expectedJson =
            "{\"id\":\"t1\",\"type\":\"TIME\",\"value\":\"T24:00\",\"temporalFunction\":false,\"phrase\":\"twelve o'clock midnight\"}";

        string actualJson = JsonSerializer.Serialize(timex,
            new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            });

        actualJson.Should().Be(expectedJson);
    }

    [Fact]
    public void TimexJsonConvert_ShouldDeserializeJsonIntoTimex()
    {
        string json =
            "{\"id\":\"t1\",\"type\":\"TIME\",\"value\":\"T24:00\",\"temporalFunction\":true,\"phrase\":\"twelve o'clock midnight\"}";
        var expectedTimex = new Timex(1, TimexType.Time, "T24:00", "twelve o'clock midnight");

        var actualTimex = JsonSerializer.Deserialize<Timex>(json,
            new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            });
        actualTimex.Should().Be(expectedTimex);
    }
}
