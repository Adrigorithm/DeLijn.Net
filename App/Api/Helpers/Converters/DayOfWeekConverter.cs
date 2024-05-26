using System.Text.Json;
using System.Text.Json.Serialization;

namespace DeLijn.Net.App.Api.Helpers.Converters;

internal class DayOfWeekConverter : JsonConverter<DayOfWeek>
{
    public override DayOfWeek Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        reader.GetString() switch
        {
            "MAANDAG" => DayOfWeek.Monday,
            "DINSDAG" => DayOfWeek.Tuesday,
            "WOENSDAG" => DayOfWeek.Wednesday,
            "DONDERDAG" => DayOfWeek.Thursday,
            "VRIJDAG" => DayOfWeek.Friday,
            "ZATERDAG" => DayOfWeek.Saturday,
            "ZONDAG" => DayOfWeek.Sunday,
            _ => throw new NotImplementedException()
        };

    public override void Write(Utf8JsonWriter writer, DayOfWeek value, JsonSerializerOptions options) =>
        writer.WriteStringValue(value switch
        {
            DayOfWeek.Sunday => "MAANDAG",
            DayOfWeek.Monday => "DINSDAG",
            DayOfWeek.Tuesday => "WOENSDAG",
            DayOfWeek.Wednesday => "DONDERDAG",
            DayOfWeek.Thursday => "VRIJDAG",
            DayOfWeek.Friday => "ZATERDAG",
            DayOfWeek.Saturday => "ZONDAG",
            _ => throw new NotImplementedException()
        });
}