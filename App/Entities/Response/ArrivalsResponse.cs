using System.Text.Json.Serialization;
using Delijn.Net.Entities;

namespace DeLijn.Net.Entities.Response;

internal record ArrivalsResponse(
    [property: JsonPropertyName("halteDoorkomsten")] IReadOnlyList<StopArrival> StopArrivals,
    [property: JsonPropertyName("links")] IReadOnlyList<Link> Links,
    [property: JsonPropertyName("doorkomstNotas")] IReadOnlyList<Note> ArrivalNotes,
    [property: JsonPropertyName("ritNotas")] IReadOnlyList<Note> RideNotes,
    [property: JsonPropertyName("omleidingen")] IReadOnlyList<Note> Diversions
);