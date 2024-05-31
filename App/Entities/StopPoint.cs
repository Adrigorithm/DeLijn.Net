using System.Text.Json.Serialization;
using DeLijn.Net.App.Api.Helpers.Converters;
using DeLijn.Net.App.Entities;

namespace DeLijn.Net.App.Entities;

public record StopPoint(
    [property: JsonPropertyName("type")] string CompanyName,
    [property: JsonPropertyName("id")][property: JsonConverter(typeof(StringIdConverter))] int Id,
    [property: JsonPropertyName("naam")] string Name,
    [property: JsonPropertyName("afstand")][property: JsonConverter(typeof(StringIdConverter))] int Distance,
    [property: JsonPropertyName("geoCoordinaat")] GeoCoordinate GeoCoordinaat
);