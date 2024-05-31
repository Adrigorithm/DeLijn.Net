using System.Text.Json.Serialization;
using DeLijn.Net.App.Api.Helpers.Converters;
using DeLijn.Net.App.Entities.Enums;

namespace DeLijn.Net.App.Entities;

public record Note(
    [property: JsonPropertyName("id")][property: JsonConverter(typeof(StringIdConverter))] int DiversionId,
    [property: JsonPropertyName("titel")] string DiversionTitle,
    [property: JsonPropertyName("ritnummer")][property: JsonConverter(typeof(StringIdConverter))] int RideId,
    [property: JsonPropertyName("haltenummer")][property: JsonConverter(typeof(StringIdConverter))] int StopId,
    [property: JsonPropertyName("omschrijving")] string Description,
    [property: JsonPropertyName("entiteitnummer")][property: JsonConverter(typeof(StringIdConverter))] int EntityId,
    [property: JsonPropertyName("lijnnummer")][property: JsonConverter(typeof(StringIdConverter))] int LineId,
    [property: JsonPropertyName("richting")][property: JsonConverter(typeof(DirectionConverter))] Direction Ritnummer
);