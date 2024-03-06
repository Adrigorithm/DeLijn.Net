using System.Text.Json.Serialization;

namespace DeLijn.Net.Entities.Response;

internal record GetAllMunicipalities(
    [property: JsonPropertyName("gemeenten")] IReadOnlyList<MunicipalityResponse> Municipalities
);