using System.Text.Json.Serialization;
using DeLijn.Net.App.Api.Helpers.Converters;

namespace DeLijn.Net.App.Entities;

public record StopPoint(
    [property: JsonPropertyName("type")] string CompanyName,
    [property: JsonPropertyName("id")][property: JsonConverter(typeof(StringIdConverter))] short Id,
    [property: JsonPropertyName("naam")] string Name,
    [property: JsonPropertyName("afstand")][property: JsonConverter(typeof(StringIdConverter))] short Distance,
    [property: JsonPropertyName("geoCoordinaat")] GeoCoordinate GeoCoordinaat
);