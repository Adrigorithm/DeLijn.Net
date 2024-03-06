using System.Text.Json.Serialization;

namespace DeLijn.Net.Entities.Response;

internal record GeoCoordinate(
    [property: JsonPropertyName("latitude")] double Latitude,
    [property: JsonPropertyName("longitude")] double Longitude
);