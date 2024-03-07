using System.Text.Json.Serialization;
using DeLijn.Net.Entities.Enums;
using DeLijn.Net.Entities.Response;

namespace DeLijn.Net.Entities;

public record Stop(
    [property: JsonPropertyName("entiteitnummer")] int EntityId,
    [property: JsonPropertyName("haltenummer")] int Id,
    [property: JsonPropertyName("omschrijving")] string Description,
    [property: JsonPropertyName("omschrijvingLang")] string DescriptionLong,
    [property: JsonPropertyName("gemeentenummer")] int MunicipalityId,
    [property: JsonPropertyName("omschrijvingGemeente")] string MunicipalityDescription,
    //[property: JsonPropertyName("districtCode")] string DistrictCode,
    [property: JsonPropertyName("geoCoordinaat")] GeoCoordinate GeoCoordinate,
    [property: JsonPropertyName("halteToegankelijkheden")] IReadOnlyList<StopAccessibility> StopAccessibilities
    //[property: JsonPropertyName("hoofdHalte")] object HoofdHalte,
    //[property: JsonPropertyName("taal")] string Taal,
);