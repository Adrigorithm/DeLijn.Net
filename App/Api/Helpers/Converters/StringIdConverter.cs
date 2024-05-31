using System.Text.Json;
using System.Text.Json.Serialization;

namespace DeLijn.Net.App.Api.Helpers.Converters;

internal class StringIdConverter : JsonConverter<int>
{
    public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        Convert.ToInt16(reader.GetString());

    public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options) =>
        writer.WriteStringValue(value.ToString());
}