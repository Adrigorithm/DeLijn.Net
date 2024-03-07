using System.Text.Json.Serialization;

namespace DeLijn.Net.Entities;

public record Municipality(
    [property: JsonPropertyName("gemeentenummer")] int Id,
    [property: JsonPropertyName("omschrijving")] string Description,
    [property: JsonPropertyName("hoofdGemeente")] Municipality? MainMunicipality
);