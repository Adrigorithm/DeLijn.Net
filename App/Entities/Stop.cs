using System.Text.Json.Serialization;
using DeLijn.Net.App.Api.Helpers.Converters;
using DeLijn.Net.App.Entities.Enums;
using DeLijn.Net.App.Entities.Response;

namespace DeLijn.Net.App.Entities;

public record Stop(
    [property: JsonPropertyName("entiteitnummer")][property: JsonConverter(typeof(StringIdInt16Converter))] short EntityId,
    [property: JsonPropertyName("haltenummer")][property: JsonConverter(typeof(StringIdInt32Converter))] int Id,
    [property: JsonPropertyName("omschrijving")] string? Description,
    [property: JsonPropertyName("omschrijvingLang")] string? DescriptionLong,
    [property: JsonPropertyName("gemeentenummer")][property: JsonConverter(typeof(StringIdInt16Converter))] short? MunicipalityId,
    [property: JsonPropertyName("omschrijvingGemeente")] string? MunicipalityDescription,
    //[property: JsonPropertyName("districtCode")] string DistrictCode,
    [property: JsonPropertyName("geoCoordinaat")] GeoCoordinate? GeoCoordinate,
    [property: JsonPropertyName("halteToegankelijkheden")] IReadOnlyList<StopAccessibility> StopAccessibilities,
    [property: JsonPropertyName("hoofdHalte")] bool? HoofdHalte
    //[property: JsonPropertyName("taal")] string Taal,
);