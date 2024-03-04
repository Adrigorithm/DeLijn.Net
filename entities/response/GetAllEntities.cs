using System.Text.Json.Serialization;
using DeLijn.Net.entities;

public record GetAllEntities(
        [property: JsonPropertyName("entiteiten")] IReadOnlyList<Entity> Entities,
        [property: JsonPropertyName("links")] IReadOnlyList<Link> Links
    );