using System.Text.Json.Serialization;

namespace DeLijn.Net.Entities.Response;

internal record LinesResponse(
    [property: JsonPropertyName("lijnen")] IReadOnlyList<Line> Lijnen,
    [property: JsonPropertyName("links")] IReadOnlyList<Link> Links
);