using System.Text.Json.Serialization;
using DeLijn.Net.App.Api.Helpers.Converters;

namespace DeLijn.Net.App.Entities;

public record StopArrival(
    [property: JsonPropertyName("haltenummer")][property: JsonConverter(typeof(StringIdConverter))] int StopId,
    [property: JsonPropertyName("doorkomsten")] IReadOnlyList<Arrival> Arrivals
);