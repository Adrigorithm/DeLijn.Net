using System.Text.Json.Serialization;

namespace DeLijn.Net.Entities.Response;

internal record ColoursResponse(
    [property: JsonPropertyName("kleuren")] IReadOnlyList<DeLijnColour> Colours,
    [property: JsonPropertyName("links")] IReadOnlyList<Link> Links
);