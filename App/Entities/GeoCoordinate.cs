using System.Text.Json.Serialization;

namespace DeLijn.Net.App.Entities;

public record GeoCoordinate
{
    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }

    public override string ToString() =>
        $"{Latitude},{Longitude}";
}