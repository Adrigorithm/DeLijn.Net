using System.Text.Json;
using System.Text.Json.Serialization;
using DeLijn.Net.App.Api.Helpers.Extensions;

namespace DeLijn.Net.App.Api.Helpers.Converters;

internal class DateTimeOffsetConverter : JsonConverter<DateTimeOffset?>
{
    public override DateTimeOffset? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var timestamp = reader.GetString();

        return timestamp?.Length switch
        {
            10 => new DateTimeOffset(DateOnly.ParseExact(timestamp, "yyyy-MM-dd"), new TimeOnly(0), TimeSpan.FromHours(1)),
            19 => new DateTimeOffset(DateTime.ParseExact(timestamp, "yyyy-MM-ddTHH:mm:ss", null), TimeSpan.FromHours(1)),
            _ => null
        };
    }

    public override void Write(Utf8JsonWriter writer, DateTimeOffset? value, JsonSerializerOptions options) =>
        throw new NotImplementedException();
}