using System.Text.Json;
using System.Text.Json.Serialization;
using DeLijn.Net.App.Entities.Enums;

namespace DeLijn.Net.App.Api.Helpers.Converters;

internal class IsStringValueConverter : JsonConverter<bool>
{
    public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        !string.IsNullOrEmpty(reader.GetString());

    public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options) =>
        throw new NotImplementedException();
}