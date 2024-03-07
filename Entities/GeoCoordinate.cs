using System.Text.Json.Serialization;

namespace DeLijn.Net.Entities.Response;

public record GeoCoordinate(
    [property: JsonPropertyName("latitude")] double Latitude,
    [property: JsonPropertyName("longitude")] double Longitude
);