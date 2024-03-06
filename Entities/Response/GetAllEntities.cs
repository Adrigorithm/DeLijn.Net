using System.Text.Json.Serialization;

namespace DeLijn.Net.Entities.Response;

internal record GetAllEntities(
    [property: JsonPropertyName("entiteiten")] IReadOnlyList<EntityResponse> Entiteiten,
    [property: JsonPropertyName("links")] IReadOnlyList<Link> Links
);