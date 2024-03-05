using System.Text.Json.Serialization;

namespace DeLijn.Net.entities;

public record Entity(
        [property: JsonPropertyName("entiteitnummer")] int Id,
        [property: JsonPropertyName("entiteitcode")] string Code,
        [property: JsonPropertyName("omschrijving")] string Description,
        [property: JsonPropertyName("links")] IReadOnlyList<Link> Links
    );