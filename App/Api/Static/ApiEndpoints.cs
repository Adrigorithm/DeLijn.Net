using System.Text;
using System.Text.Json;
using DeLijn.Net.App.Api.Helpers.Attributes;
using DeLijn.Net.App.Api.Helpers.Extensions;
using DeLijn.Net.App.Entities;
using DeLijn.Net.App.Entities.Enums;
using DeLijn.Net.App.Entities.Enums.Strinfigier;

namespace DeLijn.Net.App.Api.Static;

internal static class ApiEndpoints
{
    private const string BaseUri = "https://api.delijn.be/DLKernOpenData/api/v1/";

    internal static string GetAPIEndpoints =>
        $"{BaseUri}api";

    internal static string GetAllEntities =>
        $"{BaseUri}entiteiten";

    internal static string GetAllMunicipalities =>
        $"{BaseUri}gemeenten";

    internal static string GetAllStops =>
        $"{BaseUri}haltes";

    internal static string GetAllDiversions =>
        $"{BaseUri}omleidingen";

    internal static string GetAllLines =>
        $"{BaseUri}lijnen";

    internal static string GetAllColours =>
        $"{BaseUri}kleuren";

    internal static string GetMunicipalitiesByEntity(short entityId) =>
        $"{GetAllEntities}/{entityId}/gemeenten";

    internal static string GetStop(short entityId, int stopId, DateTimeOffset? validOnDate) =>
        AddOptionalParameters($"{GetAllStops}/{entityId}/{stopId}", ("geldigOp", validOnDate.ToDeLijnDateTimeOffsetString(true)));

    internal static string GetStopsByMunicipality(short municipalityId) =>
        $"{GetAllMunicipalities}/{municipalityId}/haltes";

    internal static string GetStopsByEntity(short entityId) =>
        $"{GetAllEntities}/{entityId}/haltes";

    internal static string GetDiversions(DateTimeOffset? startDate = null, DateTimeOffset? endDate = null) =>
        AddOptionalParameters($"{GetAllDiversions}", ("eindDatum", endDate.ToDeLijnDateTimeOffsetString(true)), ("startDatum", startDate.ToDeLijnDateTimeOffsetString(true)));

    /// <summary>
    /// return all lines currently or in the future valid for the requested entity
    /// </summary>
    /// <param name="entityId">filter by entity</param>
    /// <param name="validOnDate">filter by a date on which all returned lines should be valid</param>
    internal static string GetLinesByEntity(short entityId, DateTimeOffset? validOnDate) =>
        AddOptionalParameters($"{GetAllEntities}/{entityId}/lijnen", ("geldigOp", validOnDate.ToDeLijnDateOnlyString(true)));

    internal static string GetLinesByMunicipality(short municipalityId) =>
        $"{GetAllMunicipalities}/{municipalityId}/lijnen";

    internal static string GetMunicipalityById(short id) =>
        $"{GetAllMunicipalities}/{id}";

    internal static string GetTimetableForStop(short entityId, int stopId, DateTimeOffset? date) =>
        AddOptionalParameters($"{GetAllStops}/{entityId}/{stopId}/dienstregelingen", ("datum", date.ToDeLijnDateOnlyString(true)));

    internal static string GetLineDirectionsForStop(short entityId, int stopId, DateTimeOffset? validOnDate) =>
        AddOptionalParameters($"{GetAllStops}/{entityId}/{stopId}/lijnrichtingen", ("geldigOp", validOnDate.ToDeLijnDateTimeOffsetString(true)));

    internal static string GetDiversionsByStop(short entityId, int stopId, DateTimeOffset? date) =>
        AddOptionalParameters($"{GetAllStops}/{entityId}/{stopId}/omleidingen", ("datum", date.ToDeLijnDateOnlyString(true)));

    internal static string GetLiveDataForStop(short entityId, int stopId, short? maxResults) =>
        AddOptionalParameters($"{GetAllStops}/{entityId}/{stopId}/real-time", ("maxAantalDoorkomsten", maxResults.ToString()));

    internal static string GetDisruptionsByStop(short entityId, int stopId, DateTimeOffset? date) =>
        AddOptionalParameters($"{GetAllStops}/{entityId}/{stopId}/storingen", ("datum", date.ToDeLijnDateOnlyString(true)));

    internal static string GetStopPointsNearCoordinate(GeoCoordinate coordinate, short? maxResults, short? radius) =>
        AddOptionalParameters($"{GetAllStops}/indebuurt/{coordinate}", ("maxAantalHaltes", maxResults.ToString()), ("radius", radius.ToString()));

    internal static string GetStopsByKeys(IEnumerable<short> stopIds, DateTimeOffset? validOnDate) =>
        AddOptionalParameters($"{GetAllStops}/lijst/{stopIds.ToStopIdUrlParamList()}", ("geldigOp", validOnDate.ToDeLijnDateTimeOffsetString(true)));

    internal static string GetTimetableForStopKeys(IEnumerable<short> stopIds, DateTimeOffset? date) =>
        AddOptionalParameters($"{GetAllStops}/lijst/{stopIds.ToStopIdUrlParamList()}/dienstregelingen", ("datum", date.ToDeLijnDateOnlyString(true)));

    internal static string GetLineDirectionForStopKeys(IEnumerable<short> stopIds, DateTimeOffset? validOnDate) =>
        AddOptionalParameters($"{GetAllStops}/lijst/{stopIds.ToStopIdUrlParamList()}/lijnrichtingen", ("geldigOp", validOnDate.ToDeLijnDateTimeOffsetString(true)));

    internal static string GetDiversionsForStopKeys(IEnumerable<short> stopIds, DateTimeOffset? validOnDate) =>
        AddOptionalParameters($"{GetAllStops}/lijst/{stopIds.ToStopIdUrlParamList()}/omleidingen", ("datum", validOnDate.ToDeLijnDateOnlyString(true)));

    internal static string GetRealTimeForStopKeys(IEnumerable<short> stopIds, short? maxResults) =>
        AddOptionalParameters($"{GetAllStops}/lijst/{stopIds.ToStopIdUrlParamList()}/real-time", ("maxAantalDoorkomsten", maxResults.ToString()));

    internal static string GetDisruptionsForStopKeys(IEnumerable<short> stopIds, DateTimeOffset? validOnDate) =>
        AddOptionalParameters($"{GetAllStops}/lijst/{stopIds.ToStopIdUrlParamList()}/storingen", ("datum", validOnDate.ToDeLijnDateOnlyString(true)));

    internal static string GetColourByCode(string code) =>
        $"{GetAllColours}/{code}";

    internal static string GetLineById(short entityId, short lineId, DateTimeOffset? validOnDate) =>
        AddOptionalParameters($"{GetAllLines}/{entityId}/{lineId}", ("geldigOp", validOnDate.ToDeLijnDateTimeOffsetString(true)));

    internal static string GetMunicipalitiesServedByLine(short entityId, short lineId, DateTimeOffset? validOnDate) =>
        AddOptionalParameters($"{GetAllLines}/{entityId}/{lineId}/gemeenten", ("geldigOp", validOnDate.ToDeLijnDateTimeOffsetString(true)));

    internal static string GetColoursForLine(short entityId, short lineId, DateTimeOffset? validOnDate) =>
        AddOptionalParameters($"{GetAllLines}/{entityId}/{lineId}/lijnkleuren", ("geldigOp",validOnDate.ToDeLijnDateTimeOffsetString(true)));

    internal static string GetLineDirectionsForLine(short entityId, short lineId, DateTimeOffset? validOnDate) =>
        AddOptionalParameters($"{GetAllLines}/{entityId}/{lineId}/lijnrichtingen", ("geldigOp", validOnDate.ToDeLijnDateTimeOffsetString(true)));

    internal static string GetLineDirectionsForLineDirection(short entityId, short lineId, Direction lineDirection, DateTimeOffset? validOnDate) =>
        AddOptionalParameters($"{GetAllLines}/{entityId}/{lineId}/lijnrichtingen/{lineDirection.ToTranslatedString()}", ("geldigOp", validOnDate.ToDeLijnDateOnlyString(true)));

    internal static string GetTimetableForLineDirection(short entityId, short lineId, Direction lineDirection, DateTimeOffset? date) =>
        AddOptionalParameters($"{GetAllLines}/{entityId}/{lineId}/lijnrichtingen/{lineDirection.ToTranslatedString()}/dienstregelingen", ("datum", date.ToDeLijnDateOnlyString(true)));

    internal static string GetStopsForLineDirection(short entityId, short lineId, Direction lineDirection, DateTimeOffset? date) =>
        AddOptionalParameters($"{GetAllLines}/{entityId}/{lineId}/lijnrichtingen/{lineDirection.ToTranslatedString()}/haltes", ("geldigOp", date.ToDeLijnDateTimeOffsetString(true)));

    internal static string GetDiversionsForLineDirection(short entityId, short lineId, Direction lineDirection, DateTimeOffset? date) =>
        AddOptionalParameters($"{GetAllLines}/{entityId}/{lineId}/lijnrichtingen/{lineDirection.ToTranslatedString()}/omleidingen", ("datum", date.ToDeLijnDateOnlyString(true)));

    internal static string GetRealTimeForLineDirection(short entityId, short lineId, Direction lineDirection) =>
        $"{GetAllLines}/{entityId}/{lineId}/lijnrichtingen/{lineDirection.ToTranslatedString()}/real-time";

    internal static string GetDrivesForLineDirection(short entityId, short lineId, Direction lineDirection, short driveId, DateTimeOffset? date) =>
        AddOptionalParameters($"{GetAllLines}/{entityId}/{lineId}/lijnrichtingen/{lineDirection.ToTranslatedString()}/rit/{driveId}", ("datum", date.ToDeLijnDateOnlyString(true)));

    // internal static string GetDisruptionsForLineDirection(short entityId, short lineId, Direction lineDirection, short driveId, DateTimeOffset? date) =>
    //     $"{GetAllLines}/{entityId}/{lineId}/lijnrichtingen/{lineDirection.ToTranslatedString()}/storingen?datum={date.ToDeLijnDateOnlyString(true)}";

    private static string AddOptionalParameters(string baseUri, params IEnumerable<(string paramName, string? paramValue)> optionalParams)
    {
        optionalParams = optionalParams.Where(kvp => kvp.paramValue is not null);

        if (optionalParams.Any())
            return baseUri;
        else
        {
            var stringBuilder = new StringBuilder($"{baseUri}?");

            stringBuilder.Append($"{optionalParams.ElementAt(0).paramName}={optionalParams.ElementAt(0).paramValue}");

            for (int i = 1; i < optionalParams.Count(); i++)
            {
                stringBuilder.Append($"&{optionalParams.ElementAt(i).paramName}={optionalParams.ElementAt(i).paramValue}");
            }

            return stringBuilder.ToString();
        }
    }
}