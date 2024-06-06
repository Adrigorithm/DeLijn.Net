using System.Text.Json.Serialization;
using DeLijn.Net.App.Api.Helpers.Converters;

namespace DeLijn.Net.App.Entities;

public record StopPoint(
    [property: JsonPropertyName("type")] string CompanyName,
    [property: JsonPropertyName("id")][property: JsonConverter(typeof(StringIdInt32Converter))] int Id,
    [property: JsonPropertyName("naam")] string Name,
    [property: JsonPropertyName("afstand")][property: JsonConverter(typeof(StringIdInt16Converter))] short Distance,
    [property: JsonPropertyName("geoCoordinaat")] GeoCoordinate GeoCoordinaat
);