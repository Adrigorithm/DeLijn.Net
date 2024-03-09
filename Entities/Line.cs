using System.Text.Json.Serialization;
using DeLijn.Net.Entities.Enums;
using DeLijn.Net.Helpers.Converters;

namespace DeLijn.Net.Entities;

public record Line(
    [property: JsonPropertyName("entiteitnummer")] int EntityId,
    [property: JsonPropertyName("lijnnummer")] int Id,
    [property: JsonPropertyName("lijnnummerPubliek")] string DisplayId,
    [property: JsonPropertyName("omschrijving")] string Description,
    [property: JsonPropertyName("vervoerRegioCode")] string TransportAreaCode,
    [property: JsonPropertyName("publiek")] bool IsPublic,
    [property: JsonPropertyName("vervoertype")] [property: JsonConverter(typeof(TransportTypeConverter))] TransportType TransportType,
    [property: JsonPropertyName("bedieningtype")] [property: JsonConverter(typeof(OperatingTypeConverter))] OperatingType Bedieningtype,
    [property: JsonPropertyName("lijnGeldigVan")] [property: JsonConverter(typeof(ShortDateConverter))] string LijnGeldigVan,
    [property: JsonPropertyName("lijnGeldigTot")] [property: JsonConverter(typeof(ShortDateConverter))] string LijnGeldigTot
);