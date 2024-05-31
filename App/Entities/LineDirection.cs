using System.Text.Json.Serialization;
using DeLijn.Net.App.Api.Helpers.Converters;
using DeLijn.Net.App.Entities.Enums;

namespace DeLijn.Net.App.Entities;

/// <summary>
/// In theory there should be a lot more properties according to the documentation but the API doesn't expose these so they are not included for now.
/// </summary>
public record LineDirection(
    [property: JsonPropertyName("entiteitnummer")][property: JsonConverter(typeof(StringIdConverter))] int EntityId,
    [property: JsonPropertyName("lijnnummer")][property: JsonConverter(typeof(StringIdConverter))] int LineId,
    [property: JsonPropertyName("richting")][property: JsonConverter(typeof(DirectionConverter))] Direction Direction,
    [property: JsonPropertyName("omschrijving")] string Description
);