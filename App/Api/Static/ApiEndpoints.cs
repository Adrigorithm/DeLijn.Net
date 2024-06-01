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

    internal static string GetStop(short entityId, short stopId, DateTimeOffset? validOnDate) =>
        $"{GetAllStops}/{entityId}/{stopId}?geldigOp={validOnDate.ToDeLijnDateTimeOffsetString(true)}";

    internal static string GetStopsByMunicipality(short municipalityId) =>
        $"{GetAllMunicipalities}/{municipalityId}/haltes";

    internal static string GetStopsByEntity(short entityId) =>
        $"{GetAllEntities}/{entityId}/haltes";

    internal static string GetDiversions(DateTimeOffset? startDate = null, DateTimeOffset? endDate = null) =>
        $"{GetAllDiversions}?eindDatum={endDate.ToDeLijnDateTimeOffsetString(true)}&startDatum={startDate.ToDeLijnDateTimeOffsetString(true)}";

    /// <summary>
    /// return all lines currently or in the future valid for the requested entity
    /// </summary>
    /// <param name="entityId">filter by entity</param>
    /// <param name="validOnDate">filter by a date on which all returned lines should be valid</param>
    internal static string GetLinesByEntity(short entityId, DateTimeOffset? validOnDate) =>
        $"{GetAllEntities}/{entityId}/lijnen?geldigOp={validOnDate.ToDeLijnDateOnlyString(true)}";

    internal static string GetLinesByMunicipality(short municipalityId) =>
        $"{GetAllMunicipalities}/{municipalityId}/lijnen";

    internal static string GetMunicipalityById(short id) =>
        $"{GetAllMunicipalities}/{id}";

    internal static string GetTimetableForStop(short entityId, short stopId, DateTimeOffset? date) =>
        $"{GetAllStops}/{entityId}/{stopId}/dienstregelingen?datum={date.ToDeLijnDateOnlyString(true)}";

    internal static string GetLineDirectionsForStop(short entityId, short stopId, DateTimeOffset? validOnDate) =>
        $"{GetAllStops}/{entityId}/{stopId}/lijnrichtingen?geldigOp={validOnDate.ToDeLijnDateTimeOffsetString(true)}";

    internal static string GetDiversionsByStop(short entityId, short stopId, DateTimeOffset? date) =>
        $"{GetAllStops}/{entityId}/{stopId}/omleidingen?datum={date.ToDeLijnDateOnlyString(true)}";

    internal static string GetLiveDataForStop(short entityId, short stopId, short? maxResults) =>
        $"{GetAllStops}/{entityId}/{stopId}/real-time?maxAantalDoorkomsten={maxResults}";

    internal static string GetDisruptionsByStop(short entityId, short stopId, DateTimeOffset? date) =>
        $"{GetAllStops}/{entityId}/{stopId}/storingen?datum={date.ToDeLijnDateOnlyString(true)}";

    internal static string GetStopPointsNearCoordinate(GeoCoordinate coordinate, short? maxResults, short? radius) =>
        $"{GetAllStops}/indebuurt/{coordinate}?maxAantalHaltes={maxResults}&radius={radius}";

    internal static string GetStopsByKeys(IEnumerable<short> stopIds, DateTimeOffset? validOnDate) =>
        $"{GetAllStops}/lijst/{stopIds.ToStopIdUrlParamList()}?geldigOp={validOnDate.ToDeLijnDateTimeOffsetString(true)}";

    internal static string GetTimetableForStopKeys(IEnumerable<short> stopIds, DateTimeOffset? date) =>
        $"{GetAllStops}/lijst/{stopIds.ToStopIdUrlParamList()}/dienstregelingen?datum={date.ToDeLijnDateOnlyString(true)}";

    internal static string GetLineDirectionForStopKeys(IEnumerable<short> stopIds, DateTimeOffset? validOnDate) =>
        $"{GetAllStops}/lijst/{stopIds.ToStopIdUrlParamList()}?lijnrichtingen?geldigOp={validOnDate.ToDeLijnDateTimeOffsetString(true)}";

    internal static string GetDiversionsForStopKeys(IEnumerable<short> stopIds, DateTimeOffset? validOnDate) =>
        $"{GetAllStops}/lijst/{stopIds.ToStopIdUrlParamList()}/omleidingen?datum={validOnDate.ToDeLijnDateOnlyString(true)}";

    internal static string GetRealTimeForStopKeys(IEnumerable<short> stopIds, short? maxResults) =>
        $"{GetAllStops}/lijst/{stopIds.ToStopIdUrlParamList()}/real-time?maxAantalDoorkomsten={maxResults}";

    internal static string GetDisruptionsForStopKeys(IEnumerable<short> stopIds, DateTimeOffset? validOnDate) =>
        $"{GetAllStops}/lijst/{stopIds.ToStopIdUrlParamList()}/storingen?datum={validOnDate.ToDeLijnDateOnlyString(true)}";

    internal static string GetColourByCode(string code) =>
        $"{GetAllColours}/{code}";

    internal static string GetLineById(short entityId, short lineId, DateTimeOffset? validOnDate) =>
        $"{GetAllLines}/{entityId}/{lineId}?geldigOp={validOnDate.ToDeLijnDateTimeOffsetString(true)}";

    internal static string GetMunicipalitiesServedByLine(short entityId, short lineId, DateTimeOffset? validOnDate) =>
        $"{GetAllLines}/{entityId}/{lineId}/gemeenten?geldigOp={validOnDate.ToDeLijnDateTimeOffsetString(true)}";

    internal static string GetColoursForLine(short entityId, short lineId, DateTimeOffset? validOnDate) =>
        $"{GetAllLines}/{entityId}/{lineId}/lijnkleuren?geldigOp={validOnDate.ToDeLijnDateTimeOffsetString(true)}";

    internal static string GetLineDirectionsForLine(short entityId, short lineId, DateTimeOffset? validOnDate) =>
        $"{GetAllLines}/{entityId}/{lineId}/lijnrichtingen?geldigOp={validOnDate.ToDeLijnDateTimeOffsetString(true)}";

    internal static string GetLineDirectionsForLineDirection(short entityId, short lineId, Direction lineDirection, DateTimeOffset? validOnDate) =>
        $"{GetAllLines}/{entityId}/{lineId}/lijnrichtingen/{lineDirection.ToTranslatedString()}?geldigOp={validOnDate.ToDeLijnDateOnlyString(true)}";

    internal static string GetTimetableForLineDirection(short entityId, short lineId, Direction lineDirection, DateTimeOffset? date) =>
        $"{GetAllLines}/{entityId}/{lineId}/lijnrichtingen/{lineDirection.ToTranslatedString()}/dienstregelingen?datum={date.ToDeLijnDateOnlyString(true)}";

    internal static string GetStopsForLineDirection(short entityId, short lineId, Direction lineDirection, DateTimeOffset? date) =>
        $"{GetAllLines}/{entityId}/{lineId}/lijnrichtingen/{lineDirection.ToTranslatedString()}/haltes?geldigOp={date.ToDeLijnDateTimeOffsetString(true)}";

    internal static string GetDiversionsForLineDirection(short entityId, short lineId, Direction lineDirection, DateTimeOffset? date) =>
        $"{GetAllLines}/{entityId}/{lineId}/lijnrichtingen/{lineDirection.ToTranslatedString()}/omleidingen?datum={date.ToDeLijnDateOnlyString(true)}";

    internal static string GetRealTimeForLineDirection(short entityId, short lineId, Direction lineDirection) =>
        $"{GetAllLines}/{entityId}/{lineId}/lijnrichtingen/{lineDirection.ToTranslatedString()}/real-time";

    internal static string GetDrivesForLineDirection(short entityId, short lineId, Direction lineDirection, short driveId, DateTimeOffset? date) =>
        $"{GetAllLines}/{entityId}/{lineId}/lijnrichtingen/{lineDirection.ToTranslatedString()}/rit/{driveId}?datum={date.ToDeLijnDateOnlyString(true)}";

    internal static string GetDisruptionsForLineDirection(short entityId, short lineId, Direction lineDirection, short driveId, DateTimeOffset? date) =>
        $"{GetAllLines}/{entityId}/{lineId}/lijnrichtingen/{lineDirection.ToTranslatedString()}/storingen?datum={date.ToDeLijnDateOnlyString(true)}";

}