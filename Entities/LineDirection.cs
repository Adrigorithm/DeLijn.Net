using System.Text.Json.Serialization;
using DeLijn.Net.Api.Helpers.Converters;

namespace DeLijn.Net.Entities;

/// <summary>
/// In theory there should be a lot more properties according to the documentation but the API doesn't expose these so they are not included for now.
/// </summary>
public record LineDirection(
    [property: JsonPropertyName("entiteitnummer")] int EntityId,
    [property: JsonPropertyName("lijnnummer")] int LineId,
    [property: JsonPropertyName("richting")][property: JsonConverter(typeof(DirectionConverter))] LineDirection Direction,
    [property: JsonPropertyName("omschrijving")] string Description
);