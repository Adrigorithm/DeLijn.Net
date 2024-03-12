using System.Text.Json.Serialization;

namespace DeLijn.Net.Entities;

public record Period
{
    [JsonPropertyName("startDatum")]
    public DateTime? StartDatum { get; set; }
    [JsonPropertyName("eindDatum")]
    public DateTime? EindDatum { get; set; }

    [JsonIgnore]
    public TimeSpan? Duration =>
        StartDatum is null || EindDatum is null 
            ? EindDatum - StartDatum
            : null;
}