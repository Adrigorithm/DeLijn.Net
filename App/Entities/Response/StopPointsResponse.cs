using System.Text.Json.Serialization;
using DeLijn.Net.App.Entities;

namespace DeLijn.Net.App.Entities.Response;

internal record StopPointsResponse(
    [property: JsonPropertyName("haltes")] IReadOnlyList<StopPoint> StopPoints,
    [property: JsonPropertyName("links")] IReadOnlyList<Link> Links
);