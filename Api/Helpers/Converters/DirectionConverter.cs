using System.Text.Json;
using System.Text.Json.Serialization;
using DeLijn.Net.Entities.Enums;
using DeLijn.Net.Entities.Enums.Strinfigier;

namespace DeLijn.Net.Api.Helpers.Converters;

internal class DirectionConverter : JsonConverter<Direction>
{
    public override Direction Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        reader.GetString() switch
        {
            "HEEN" => Direction.To,
            "TERUG" => Direction.Back,
            _ => Direction.Unknown
        };

    public override void Write(Utf8JsonWriter writer, Direction value, JsonSerializerOptions options) =>
        writer.WriteStringValue(value.ToTranslatedString());
}