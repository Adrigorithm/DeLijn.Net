using System.Text.Json.Serialization;

namespace DeLijn.Net.entities;

public record Entity(
        [property: JsonPropertyName("entiteitnummer")] int Entiteitnummer,
        [property: JsonPropertyName("entiteitcode")] string Entiteitcode,
        [property: JsonPropertyName("omschrijving")] string Omschrijving,
        [property: JsonPropertyName("links")] IReadOnlyList<Link> Links
    );