using System.Text.Json;
using System.Text.Json.Serialization;
using DeLijn.Net.Entities.Enums;

namespace DeLijn.Net.Api.Helpers.Converters;

internal class IsStringValueConverter : JsonConverter<bool>
{
    public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        !string.IsNullOrEmpty(reader.GetString());

    public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options) =>
        throw new NotImplementedException();
}