using System.Text.Json.Serialization;

namespace DeLijn.Net.App.Entities;

public record StopArrival(
    [property: JsonPropertyName("haltenummer")] int StopId,
    [property: JsonPropertyName("doorkomsten")] IReadOnlyList<Arrival> Arrivals
);