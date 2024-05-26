using System.Text.Json.Serialization;
using DeLijn.Net.App.Entities;

namespace DeLijn.Net.App.Entities;

public record StopPoint(
    [property: JsonPropertyName("type")] string CompanyName,
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("naam")] string Name,
    [property: JsonPropertyName("afstand")] int Distance,
    [property: JsonPropertyName("geoCoordinaat")] GeoCoordinate GeoCoordinaat
);