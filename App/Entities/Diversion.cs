using System.Text.Json.Serialization;
using DeLijn.Net.App.Api.Helpers.Converters;
using DeLijn.Net.App.Entities;
using DeLijn.Net.App.Entities.Enums;

namespace DeLijn.Net.App.Entities;

public record Diversion(
    [property: JsonPropertyName("titel")] string Titel,
    [property: JsonPropertyName("omschrijving")] string Omschrijving,
    [property: JsonPropertyName("periode")] Period Period,
    [property: JsonPropertyName("lijnrichtingen")] IReadOnlyList<LineDirection> Lijnrichtingen,
    [property: JsonPropertyName("haltes")] IReadOnlyList<Stop> Stops,
    [property: JsonPropertyName("referentieOmleiding")] int? ReferentieOmleiding,
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("omleidingsDagen")][property: JsonConverter(typeof(DayOfWeekConverter))] IReadOnlyList<DayOfWeek> OmleidingsDagen
);