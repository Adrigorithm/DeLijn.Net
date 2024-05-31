using System.Text.Json.Serialization;
using DeLijn.Net.App.Api.Helpers.Converters;
using DeLijn.Net.App.Entities.Enums;

namespace DeLijn.Net.App.Entities;

public record Line(
    [property: JsonPropertyName("entiteitnummer")][property: JsonConverter(typeof(StringIdConverter))] int EntityId,
    [property: JsonPropertyName("lijnnummer")][property: JsonConverter(typeof(StringIdConverter))] int Id,
    [property: JsonPropertyName("lijnnummerPubliek")] string DisplayId,
    [property: JsonPropertyName("omschrijving")] string Description,
    [property: JsonPropertyName("vervoerRegioCode")] string TransportAreaCode,
    [property: JsonPropertyName("publiek")] bool IsPublic,
    [property: JsonPropertyName("vervoertype")][property: JsonConverter(typeof(TransportTypeConverter))] TransportType TransportType,
    [property: JsonPropertyName("bedieningtype")][property: JsonConverter(typeof(OperatingTypeConverter))] OperatingType Bedieningtype,
    [property: JsonPropertyName("lijnGeldigVan")][property: JsonConverter(typeof(DateTimeOffsetConverter))] DateTimeOffset LijnGeldigVan,
    [property: JsonPropertyName("lijnGeldigTot")][property: JsonConverter(typeof(DateTimeOffsetConverter))] DateTimeOffset LijnGeldigTot
);