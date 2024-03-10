using System.Text.Json.Serialization;

namespace DeLijn.Net.Entities;

public record DeLijnColour(
    [property: JsonPropertyName("code")] string Code,
    [property: JsonPropertyName("omschrijving")] string Omschrijving,
    [property: JsonPropertyName("rgb")] Rgb Rgb,
    [property: JsonPropertyName("hex")] string Hex
);