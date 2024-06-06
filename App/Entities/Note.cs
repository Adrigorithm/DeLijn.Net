using System.Text.Json.Serialization;
using DeLijn.Net.App.Api.Helpers.Converters;
using DeLijn.Net.App.Entities.Enums;

namespace DeLijn.Net.App.Entities;

public record Note(
    [property: JsonPropertyName("id")][property: JsonConverter(typeof(StringIdInt16Converter))] short DiversionId,
    [property: JsonPropertyName("titel")] string DiversionTitle,
    [property: JsonPropertyName("ritnummer")][property: JsonConverter(typeof(StringIdInt16Converter))] short RideId,
    [property: JsonPropertyName("haltenummer")][property: JsonConverter(typeof(StringIdInt32Converter))] int StopId,
    [property: JsonPropertyName("omschrijving")] string Description,
    [property: JsonPropertyName("entiteitnummer")][property: JsonConverter(typeof(StringIdInt16Converter))] short EntityId,
    [property: JsonPropertyName("lijnnummer")][property: JsonConverter(typeof(StringIdInt16Converter))] short LineId,
    [property: JsonPropertyName("richting")][property: JsonConverter(typeof(DirectionConverter))] Direction Ritnummer
);