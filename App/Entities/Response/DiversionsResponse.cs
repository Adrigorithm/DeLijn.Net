using System.Text.Json.Serialization;
using DeLijn.Net.App.Entities.Response;

namespace DeLijn.Net.App.Entities.Response;

internal record DiversionsResponse(
    [property: JsonPropertyName("omleidingen")] IReadOnlyList<Diversion> Diversions,
    [property: JsonPropertyName("links")] IReadOnlyList<Link> Links,
    [property: JsonPropertyName("storingen")] IReadOnlyList<Diversion> Faults
);
