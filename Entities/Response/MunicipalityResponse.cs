using System.Text.Json.Serialization;

namespace DeLijn.Net.Entities.Response;

internal record MunicipalityResponse(
    [property: JsonPropertyName("gemeentenummer")] int Id,
    [property: JsonPropertyName("omschrijving")] string Description,
    [property: JsonPropertyName("links")] IReadOnlyList<Link> Links
);