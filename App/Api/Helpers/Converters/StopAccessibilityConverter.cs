using System.Text.Json;
using System.Text.Json.Serialization;
using DeLijn.Net.Entities.Enums;

namespace DeLijn.Net.Api.Helpers.Converters;

internal class StopAccessibilityConverter : JsonConverter<StopAccessibility>
{
    public override StopAccessibility Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        reader.GetString() switch
        {
            "MOTORISCHE_BEPERKING" => StopAccessibility.MotorImpairment,
            "MOTORISCH_MET_ASSIST" => StopAccessibility.MotorImpairmentAssisted,
            "VISUELE_BEPERKING" => StopAccessibility.VisualImpairment,
            _ => StopAccessibility.Unknown
        };

    public override void Write(Utf8JsonWriter writer, StopAccessibility value, JsonSerializerOptions options) =>
        writer.WriteStringValue(value switch
        {
            StopAccessibility.MotorImpairment => "MOTORISCHE_BEPERKING",
            StopAccessibility.MotorImpairmentAssisted => "MOTORISCH_MET_ASSIST",
            StopAccessibility.VisualImpairment => "VISUELE_BEPERKING",
            _ => string.Empty
        });
}