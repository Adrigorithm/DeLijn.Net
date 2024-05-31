using System.Text.Json;
using System.Text.Json.Serialization;

namespace DeLijn.Net.App.Api.Helpers.Converters;

internal class StringDoubleConverter : JsonConverter<double>
{
    public override double Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        Convert.ToDouble(reader.GetString());

    public override void Write(Utf8JsonWriter writer, double value, JsonSerializerOptions options) =>
        writer.WriteStringValue(value.ToString());
}