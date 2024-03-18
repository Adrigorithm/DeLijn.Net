using System.Text.Json.Serialization;
using DeLijn.Net.Api.Helpers.Converters;
using DeLijn.Net.Entities.Enums;

namespace DeLijn.Net.Entities;

public record Arrival(
    [property: JsonPropertyName("entiteitnummer")] int EntityId,
    [property: JsonPropertyName("lijnnummer")] int LineId,
    [property: JsonPropertyName("richting")][property: JsonConverter(typeof(DirectionConverter))] Direction Direction,
    [property: JsonPropertyName("ritnummer")] string RideId,
    [property: JsonPropertyName("bestemming")] string Destination,
    [property: JsonPropertyName("plaatsBestemming")] string DestinationPlace,
    [property: JsonPropertyName("vias")] string[] DiversionStops,
    [property: JsonPropertyName("dienstregelingTijdstip")] DateTime? DienstregelingTijdstip
);