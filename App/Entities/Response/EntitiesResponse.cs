using System.Text.Json.Serialization;

namespace DeLijn.Net.App.Entities.Response;

internal record EntitiesResponse(
    [property: JsonPropertyName("entiteiten")] IReadOnlyList<Entity> Entities,
    [property: JsonPropertyName("links")] IReadOnlyList<Link> Links
);
