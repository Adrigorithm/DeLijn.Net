using System.Text.Json.Serialization;
using DeLijn.Net.App.Api.Helpers.Converters;

namespace DeLijn.Net.App.Entities;

public record Municipality(
    [property: JsonPropertyName("gemeentenummer")][property: JsonConverter(typeof(StringIdConverter))] short Id,
    [property: JsonPropertyName("omschrijving")] string Description,
    [property: JsonPropertyName("hoofdGemeente")] Municipality? MainMunicipality
);