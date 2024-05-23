using System.Text.Json.Serialization;
using DeLijn.Net.Api.Helpers.Converters;
using DeLijn.Net.Entities.Enums;

namespace DeLijn.Net.Entities;

public record Note(
    [property: JsonPropertyName("id")] int DiversionId,
    [property: JsonPropertyName("titel")] string DiversionTitle,
    [property: JsonPropertyName("ritnummer")] int RideId,
    [property: JsonPropertyName("haltenummer")] int StopId,
    [property: JsonPropertyName("omschrijving")] string Description,
    [property: JsonPropertyName("entiteitnummer")] int EntityId,
    [property: JsonPropertyName("lijnnummer")] int LineId,
    [property: JsonPropertyName("richting")][property: JsonConverter(typeof(DirectionConverter))] Direction Ritnummer
);