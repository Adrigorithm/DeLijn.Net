using System.Text.Json.Serialization;

namespace DeLijn.Net.App.Entities.Response;

internal record MunicipalitiesResponse(
    [property: JsonPropertyName("gemeenten")] IReadOnlyList<Municipality> Municipalities,
    [property: JsonPropertyName("links")] IReadOnlyList<Link> Links
);