using System.Text.Json.Serialization;
using DeLijn.Net.App.Api.Helpers.Converters;
using DeLijn.Net.App.Entities.Response;

namespace DeLijn.Net.App.Entities;

public record Entity(
    [property: JsonPropertyName("entiteitnummer")][property: JsonConverter(typeof(StringIdConverter))] short Id,
    [property: JsonPropertyName("entiteitcode")] string Code,
    [property: JsonPropertyName("omschrijving")] string Description
);