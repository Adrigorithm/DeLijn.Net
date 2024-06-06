using System.Text.Json;
using System.Text.Json.Serialization;

namespace DeLijn.Net.App.Api.Helpers.Converters;

internal class StringIdInt16Converter : JsonConverter<short>
{
    public override short Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        Convert.ToInt16(reader.GetString());

    public override void Write(Utf8JsonWriter writer, short value, JsonSerializerOptions options) =>
        writer.WriteStringValue(value.ToString());
}