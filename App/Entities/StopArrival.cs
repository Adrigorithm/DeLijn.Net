using System.Text.Json.Serialization;
using DeLijn.Net.App.Api.Helpers.Converters;

namespace DeLijn.Net.App.Entities;

public record StopArrival(
    [property: JsonPropertyName("haltenummer")][property: JsonConverter(typeof(StringIdConverter))] short StopId,
    [property: JsonPropertyName("doorkomsten")] IReadOnlyList<Arrival> Arrivals
);