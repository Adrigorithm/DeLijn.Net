using System.Text.Json.Serialization;
using DeLijn.Net.App.Api.Helpers.Converters;

namespace DeLijn.Net.App.Entities;

public record GeoCoordinate
{
    [JsonPropertyName("latitude")]
    [JsonConverter(typeof(StringDoubleConverter))]
    public double Latitude { get; set; }

    [JsonPropertyName("longitude")]
    [JsonConverter(typeof(StringDoubleConverter))]
    public double Longitude { get; set; }

    public override string ToString() =>
        $"{Latitude},{Longitude}";
}