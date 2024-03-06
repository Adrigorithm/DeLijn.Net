using System.Text.Json.Serialization;

namespace DeLijn.Net.Entities.Response;

internal record EntityResponse(
    [property: JsonPropertyName("entiteitnummer")] string Id,
    [property: JsonPropertyName("entiteitcode")] string Code,
    [property: JsonPropertyName("omschrijving")] string Description,
    [property: JsonPropertyName("links")] IReadOnlyList<Link> Links
);