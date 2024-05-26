using System.Text.Json.Serialization;
using DeLijn.Net.App.Entities;
using DeLijn.Net.App.Entities.Response;

namespace DeLijn.Net.App.Entities.Response;

internal record LineDirectionsResponse(
    [property: JsonPropertyName("lijnrichtingen")] IReadOnlyList<LineDirection> LineDirections,
    [property: JsonPropertyName("links")] IReadOnlyList<Link> Links
);
