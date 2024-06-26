using System.Text.Json.Serialization;

namespace DeLijn.Net.App.Entities.Response;

internal record LinesResponse(
    [property: JsonPropertyName("lijnen")] IReadOnlyList<Line> Lines,
    [property: JsonPropertyName("links")] IReadOnlyList<Link> Links
);