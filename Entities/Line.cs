using System.Text.Json.Serialization;
using DeLijn.Net.Entities.Enums;

namespace DeLijn.Net.Entities;

public record Line(
    [property: JsonPropertyName("entiteitnummer")] int EntityId,
    [property: JsonPropertyName("lijnnummer")] int Id,
    [property: JsonPropertyName("lijnnummerPubliek")] string DisplayId,
    [property: JsonPropertyName("omschrijving")] string Description,
    [property: JsonPropertyName("vervoerRegioCode")] string TransportAreaCode,
    [property: JsonPropertyName("publiek")] bool IsPublic,
    [property: JsonPropertyName("vervoertype")] TransportType TransportType,
    [property: JsonPropertyName("bedieningtype")] string Bedieningtype,
    [property: JsonPropertyName("lijnGeldigVan")] string LijnGeldigVan,
    [property: JsonPropertyName("lijnGeldigTot")] string LijnGeldigTot
);