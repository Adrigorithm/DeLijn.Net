using System.Text.Json.Serialization;

namespace DeLijn.Net.App.Entities.Response;

internal record EntityResponse(
    [property: JsonPropertyName("entiteitnummer")] int Id,
    [property: JsonPropertyName("entiteitcode")] string Code,
    [property: JsonPropertyName("omschrijving")] string Description,
    [property: JsonPropertyName("links")] IReadOnlyList<Link> Links
);