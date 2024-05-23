using System.Text.Json.Serialization;
using DeLijn.Net.Entities;
using DeLijn.Net.Entities.Response;

namespace Delijn.Net.Entities.Response;

internal record LineDirectionsResponse(
    [property: JsonPropertyName("lijnrichtingen")] IReadOnlyList<LineDirection> LineDirections,
    [property: JsonPropertyName("links")] IReadOnlyList<Link> Links
);
