using System.Text.Json;
using System.Text.Json.Serialization;

namespace DeLijn.Net.Helpers.Converters;

internal class ShortDateConverter : JsonConverter<DateOnly>
{
    /// <summary>
    /// Converts a string of format yyyy-MM-dd to a DateOnly object
    /// </summary>
    /// <param name="reader"></param>
    /// <param name="typeToConvert"></param>
    /// <param name="options"></param>
    /// <returns>A DateOnly object representing the string or a 00/00/00 DateOnly</returns>
    public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        DateOnly.ParseExact(reader.GetString() ?? "0000-00-00", "yyyy-MM-dd");

    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options) =>
        value.ToString("yyyy-MM-dd");
}