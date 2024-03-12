using System.Text.Json.Serialization;
using DeLijn.Net.Entities;
using DeLijn.Net.Entities.Enums;

namespace Delijn.Net.Entities;

public record Diversion(
    [property: JsonPropertyName("titel")] string Titel,
    [property: JsonPropertyName("omschrijving")] string Omschrijving,
    [property: JsonPropertyName("periode")] Period Period,
    [property: JsonPropertyName("lijnrichtingen")] IReadOnlyList<LineDirection> Lijnrichtingen,
    [property: JsonPropertyName("haltes")] IReadOnlyList<Stop> Stops,
    [property: JsonPropertyName("referentieOmleiding")] int? ReferentieOmleiding,
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("omleidingsDagen")] IReadOnlyList<DayOfWeek> OmleidingsDagen
);