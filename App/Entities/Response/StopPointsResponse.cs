using System.Text.Json.Serialization;
using Delijn.Net.Entities;

namespace DeLijn.Net.Entities.Response;

internal record StopPointsResponse(
    [property: JsonPropertyName("haltes")] IReadOnlyList<StopPoint> StopPoints,
    [property: JsonPropertyName("links")] IReadOnlyList<Link> Links
);