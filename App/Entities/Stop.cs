using System.Text.Json.Serialization;
using DeLijn.Net.App.Api.Helpers.Converters;
using DeLijn.Net.App.Entities.Enums;
using DeLijn.Net.App.Entities.Response;

namespace DeLijn.Net.App.Entities;

public record Stop(
    [property: JsonPropertyName("entiteitnummer")][property: JsonConverter(typeof(StringIdConverter))] short EntityId,
    [property: JsonPropertyName("haltenummer")][property: JsonConverter(typeof(StringIdConverter))] short Id,
    [property: JsonPropertyName("omschrijving")] string Description,
    [property: JsonPropertyName("omschrijvingLang")] string DescriptionLong,
    [property: JsonPropertyName("gemeentenummer")][property: JsonConverter(typeof(StringIdConverter))] short MunicipalityId,
    [property: JsonPropertyName("omschrijvingGemeente")] string MunicipalityDescription,
    //[property: JsonPropertyName("districtCode")] string DistrictCode,
    [property: JsonPropertyName("geoCoordinaat")] GeoCoordinate GeoCoordinate,
    [property: JsonPropertyName("halteToegankelijkheden")] IReadOnlyList<StopAccessibility> StopAccessibilities
//[property: JsonPropertyName("hoofdHalte")] object HoofdHalte,
//[property: JsonPropertyName("taal")] string Taal,
);