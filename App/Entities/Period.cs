using System.Text.Json.Serialization;
using DeLijn.Net.App.Api.Helpers.Converters;

namespace DeLijn.Net.App.Entities;

public record Period
{
    [JsonPropertyName("startDatum")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset? StartDatum { get; set; }

    [JsonPropertyName("eindDatum")]
    [JsonConverter(typeof(DateTimeOffsetConverter))]
    public DateTimeOffset? EindDatum { get; set; }

    [JsonIgnore]
    public TimeSpan? Duration =>
        StartDatum is null || EindDatum is null
            ? EindDatum - StartDatum
            : null;
}