using System.Text.Json.Serialization;

namespace DeLijn.Net.Entities.Response;

internal record StopsResponse(
    [property: JsonPropertyName("haltes")] IReadOnlyList<Stop> Stops,
    [property: JsonPropertyName("links")] IReadOnlyList<Link> Links
);