using System.Text.Json.Serialization;

namespace DeLijn.Net.Entities;

internal record Rgb(
    [property: JsonPropertyName("rood")] int Rood,
    [property: JsonPropertyName("groen")] int Groen,
    [property: JsonPropertyName("blauw")] int Blauw
);