using System.Text.Json.Serialization;
using DeLijn.Net.App.Api.Helpers.Converters;
using DeLijn.Net.App.Entities.Enums;

namespace DeLijn.Net.App.Entities;

public record Arrival(
    [property: JsonPropertyName("entiteitnummer")][property: JsonConverter(typeof(StringIdInt16Converter))] short EntityId,
    [property: JsonPropertyName("lijnnummer")][property: JsonConverter(typeof(StringIdInt16Converter))] short LineId,
    [property: JsonPropertyName("richting")][property: JsonConverter(typeof(DirectionConverter))] Direction Direction,
    [property: JsonPropertyName("ritnummer")] string RideId,
    [property: JsonPropertyName("bestemming")] string Destination,
    [property: JsonPropertyName("plaatsBestemming")] string DestinationPlace,
    [property: JsonPropertyName("vias")] IReadOnlyList<string> DiversionStops,
    [property: JsonPropertyName("haltenummer")][property: JsonConverter(typeof(StringIdInt32Converter))] int StopId,
    [property: JsonPropertyName("dienstregelingTijdstip")][property: JsonConverter(typeof(DateTimeOffsetConverter))] DateTimeOffset? TimetableTimestamp,
    [property: JsonPropertyName("doorkomstTijdstip")][property: JsonConverter(typeof(DateTimeOffsetConverter))] DateTimeOffset? RealTimeTimestamp,
    [property: JsonPropertyName("vrtnum")][property: JsonConverter(typeof(StringIdInt16Converter))] short VehicleId,
    [property: JsonPropertyName("predictionStatussen")] IReadOnlyList<StatusPrediction> StatusPredictions,
    [property: JsonPropertyName("status")][property: JsonConverter(typeof(IsStringValueConverter))] bool? IsCancelled
);