using System.Text.Json;
using System.Text.Json.Serialization;
using DeLijn.Net.Entities.Enums;

namespace DeLijn.Net.Helpers.Converters;

internal class TransportTypeConverter : JsonConverter<TransportType>
{
    public override TransportType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        reader.GetString() switch
        {
            "ALLE" => TransportType.All,
            "BUS" => TransportType.Bus,
            "METRO" => TransportType.Metro,
            "TRAM" => TransportType.Tram,
            "TREIN" => TransportType.Train,
            _ => TransportType.Unknown
        };

    public override void Write(Utf8JsonWriter writer, TransportType value, JsonSerializerOptions options) =>
        writer.WriteStringValue(value switch
        {
            TransportType.All => "ALLE",
            TransportType.Bus => "BUS",
            TransportType.Metro => "METRO",
            TransportType.Tram => "TRAM",
            TransportType.Train => "TREIN",
            _ => string.Empty
        });
}