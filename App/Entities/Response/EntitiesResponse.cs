using System.Text.Json.Serialization;
using DeLijn.Net.App.Entities;

namespace DeLijn.Net.Entities.Response;

internal record EntitiesResponse(
    [property: JsonPropertyName("entiteiten")] IReadOnlyList<Entity> Entities,
    [property: JsonPropertyName("links")] IReadOnlyList<Link> Links
);