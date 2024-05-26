using System.Text.Json;
using System.Text.Json.Serialization;
using DeLijn.Net.App.Entities.Enums;

namespace DeLijn.Net.App.Api.Helpers.Converters;

internal class StatusPredictionConverter : JsonConverter<StatusPrediction>
{
    public override StatusPrediction Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        reader.GetString() switch
        {
            "GEENREALTIME" => StatusPrediction.NoRealTime,
            "GESCHRAPT" => StatusPrediction.Cancelled,
            "REALTIME" => StatusPrediction.RealTime,
            "VERSTREKEN" => StatusPrediction.Expired,
            _ => StatusPrediction.Unknown
        };

    public override void Write(Utf8JsonWriter writer, StatusPrediction value, JsonSerializerOptions options) =>
        writer.WriteStringValue(value switch
        {
            StatusPrediction.NoRealTime => "GEENREALTIME",
            StatusPrediction.Cancelled => "GESCHRAPT",
            StatusPrediction.RealTime => "REALTIME",
            StatusPrediction.Expired => "VERSTREKEN",
            _ => string.Empty,
        });
}