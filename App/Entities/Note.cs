using System.Text.Json.Serialization;
using DeLijn.Net.App.Api.Helpers.Converters;
using DeLijn.Net.App.Entities.Enums;

namespace DeLijn.Net.App.Entities;

public record Note(
    [property: JsonPropertyName("id")][property: JsonConverter(typeof(StringIdConverter))] short DiversionId,
    [property: JsonPropertyName("titel")] string DiversionTitle,
    [property: JsonPropertyName("ritnummer")][property: JsonConverter(typeof(StringIdConverter))] short RideId,
    [property: JsonPropertyName("haltenummer")][property: JsonConverter(typeof(StringIdConverter))] short StopId,
    [property: JsonPropertyName("omschrijving")] string Description,
    [property: JsonPropertyName("entiteitnummer")][property: JsonConverter(typeof(StringIdConverter))] short EntityId,
    [property: JsonPropertyName("lijnnummer")][property: JsonConverter(typeof(StringIdConverter))] short LineId,
    [property: JsonPropertyName("richting")][property: JsonConverter(typeof(DirectionConverter))] Direction Ritnummer
);