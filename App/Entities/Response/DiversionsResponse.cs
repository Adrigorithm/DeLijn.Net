using System.Text.Json.Serialization;
using DeLijn.Net.Entities.Response;

namespace Delijn.Net.Entities.Response;

internal record DiversionsResponse(
    [property: JsonPropertyName("omleidingen")] IReadOnlyList<Diversion> Diversions,
    [property: JsonPropertyName("links")] IReadOnlyList<Link> Links,
    [property: JsonPropertyName("storingen")] IReadOnlyList<Diversion> Faults
);
