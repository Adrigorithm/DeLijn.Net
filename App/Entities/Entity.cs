using System.Text.Json.Serialization;
using DeLijn.Net.App.Entities.Response;

namespace DeLijn.Net.App.Entities;

public record Entity(
    [property: JsonPropertyName("entiteitnummer")] string Id,
    [property: JsonPropertyName("entiteitcode")] string Code,
    [property: JsonPropertyName("omschrijving")] string Description
);