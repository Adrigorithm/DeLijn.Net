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
    [property: JsonPropertyName("vias")] IReadOnlyList<string> DiversionStops,
    [property: JsonPropertyName("haltenummer")] int StopId,
    [property: JsonPropertyName("dienstregelingTijdstip")][property: JsonConverter(typeof(DateTimeOffsetConverter))] DateTimeOffset? TimetableTimestamp,
    [property: JsonPropertyName("doorkomstTijdstip")][property: JsonConverter(typeof(DateTimeOffsetConverter))] DateTimeOffset? RealTimeTimestamp,
    [property: JsonPropertyName("vrtnum")] int VehicleId,
    [property: JsonPropertyName("predictionStatussen")] IReadOnlyList<StatusPrediction> StatusPredictions,
    [property: JsonPropertyName("status")][property: JsonConverter(typeof(IsStringValueConverter))] bool? IsCancelled
);