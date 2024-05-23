using System.Text.Json;
using Delijn.Net.Api.Helpers.Attributes;
using DeLijn.Net.Api.Helpers.Extensions;
using DeLijn.Net.Entities;
using DeLijn.Net.Entities.Enums;
using DeLijn.Net.Entities.Enums.Strinfigier;

namespace DeLijn.Net.Api.Static;

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

    internal static string GetMunicipalitiesByEntity(int entityId) =>
        $"{GetAllEntities}/{entityId}/gemeenten";

    internal static string GetStop(int entityId, int stopId, DateTimeOffset? validOnDate) =>
        $"{GetAllStops}/{entityId}/{stopId}?geldigOp={validOnDate.ToDeLijnDateTimeOffsetString(true)}";

    internal static string GetStopsByMunicipality(int municipalityId) =>
        $"{GetAllMunicipalities}/{municipalityId}/haltes";

    internal static string GetStopsByEntity(int entityId) =>
        $"{GetAllEntities}/{entityId}/haltes";

    internal static string GetDiversions(DateTimeOffset? startDate = null, DateTimeOffset? endDate = null) =>
        $"{GetAllDiversions}?eindDatum={endDate.ToDeLijnDateTimeOffsetString(true)}&startDatum={startDate.ToDeLijnDateTimeOffsetString(true)}";

    /// <summary>
    /// return all lines currently or in the future valid for the requested entity
    /// </summary>
    /// <param name="entityId">filter by entity</param>
    /// <param name="validOnDate">filter by a date on which all returned lines should be valid</param>
    internal static string GetLinesByEntity(int entityId, DateTimeOffset? validOnDate) =>
        $"{GetAllEntities}/{entityId}/lijnen?geldigOp={validOnDate.ToDeLijnDateOnlyString(true)}";

    internal static string GetLinesByMunicipality(int municipalityId) =>
        $"{GetAllMunicipalities}/{municipalityId}/lijnen";

    internal static string GetMunicipalityById(int id) =>
        $"{GetAllMunicipalities}/{id}";

    internal static string GetTimetableForStop(int entityId, int stopId, DateTimeOffset? date) =>
        $"{GetAllStops}/{entityId}/{stopId}/dienstregelingen?datum={date.ToDeLijnDateOnlyString(true)}";

    internal static string GetLineDirectionsForStop(int entityId, int stopId, DateTimeOffset? validOnDate) =>
        $"{GetAllStops}/{entityId}/{stopId}/lijnrichtingen?geldigOp={validOnDate.ToDeLijnDateTimeOffsetString(true)}";

    internal static string GetDiversionsByStop(int entityId, int stopId, DateTimeOffset? date) =>
        $"{GetAllStops}/{entityId}/{stopId}/omleidingen?datum={date.ToDeLijnDateOnlyString(true)}";

    internal static string GetLiveDataForStop(int entityId, int stopId, int? maxResults) =>
        $"{GetAllStops}/{entityId}/{stopId}/real-time?maxAantalDoorkomsten={maxResults}";

    internal static string GetDisruptionsByStop(int entityId, int stopId, DateTimeOffset? date) =>
        $"{GetAllStops}/{entityId}/{stopId}/storingen?datum={date.ToDeLijnDateOnlyString(true)}";

    internal static string GetStopPointsNearCoordinate(GeoCoordinate coordinate, int? maxResults, int? radius) =>
        $"{GetAllStops}/indebuurt/{coordinate}?maxAantalHaltes={maxResults}&radius={radius}";

    internal static string GetStopsByKeys(IEnumerable<int> stopIds, DateTimeOffset? validOnDate) =>
        $"{GetAllStops}/lijst/{stopIds.ToStopIdUrlParamList()}?geldigOp={validOnDate.ToDeLijnDateTimeOffsetString(true)}";

    internal static string GetTimetableForStopKeys(IEnumerable<int> stopIds, DateTimeOffset? date) =>
        $"{GetAllStops}/lijst/{stopIds.ToStopIdUrlParamList()}/dienstregelingen?datum={date.ToDeLijnDateOnlyString(true)}";

    internal static string GetLineDirectionForStopKeys(IEnumerable<int> stopIds, DateTimeOffset? validOnDate) =>
        $"{GetAllStops}/lijst/{stopIds.ToStopIdUrlParamList()}?lijnrichtingen?geldigOp={validOnDate.ToDeLijnDateTimeOffsetString(true)}";

    internal static string GetDiversionsForStopKeys(IEnumerable<int> stopIds, DateTimeOffset? validOnDate) =>
        $"{GetAllStops}/lijst/{stopIds.ToStopIdUrlParamList()}/omleidingen?datum={validOnDate.ToDeLijnDateOnlyString(true)}";

    internal static string GetRealTimeForStopKeys(IEnumerable<int> stopIds, int? maxResults) =>
        $"{GetAllStops}/lijst/{stopIds.ToStopIdUrlParamList()}/real-time?maxAantalDoorkomsten={maxResults}";

    internal static string GetDisruptionsForStopKeys(IEnumerable<int> stopIds, DateTimeOffset? validOnDate) =>
        $"{GetAllStops}/lijst/{stopIds.ToStopIdUrlParamList()}/storingen?datum={validOnDate.ToDeLijnDateOnlyString(true)}";

    internal static string GetColourByCode(string code) =>
        $"{GetAllColours}/{code}";

    internal static string GetLineById(int entityId, int lineId, DateTimeOffset? validOnDate) =>
        $"{GetAllLines}/{entityId}/{lineId}?geldigOp={validOnDate.ToDeLijnDateTimeOffsetString(true)}";

    internal static string GetMunicipalitiesServedByLine(int entityId, int lineId, DateTimeOffset? validOnDate) =>
        $"{GetAllLines}/{entityId}/{lineId}/gemeenten?geldigOp={validOnDate.ToDeLijnDateTimeOffsetString(true)}";

    internal static string GetColoursForLine(int entityId, int lineId, DateTimeOffset? validOnDate) =>
        $"{GetAllLines}/{entityId}/{lineId}/lijnkleuren?geldigOp={validOnDate.ToDeLijnDateTimeOffsetString(true)}";

    internal static string GetLineDirectionsForLine(int entityId, int lineId, DateTimeOffset? validOnDate) =>
        $"{GetAllLines}/{entityId}/{lineId}/lijnrichtingen?geldigOp={validOnDate.ToDeLijnDateTimeOffsetString(true)}";

    internal static string GetLineDirectionsForLineDirection(int entityId, int lineId, Direction lineDirection, DateTimeOffset? validOnDate) =>
        $"{GetAllLines}/{entityId}/{lineId}/lijnrichtingen/{lineDirection.ToTranslatedString()}?geldigOp={validOnDate.ToDeLijnDateOnlyString(true)}";

    internal static string GetTimetableForLineDirection(int entityId, int lineId, Direction lineDirection, DateTimeOffset? date) =>
        $"{GetAllLines}/{entityId}/{lineId}/lijnrichtingen/{lineDirection.ToTranslatedString()}/dienstregelingen?datum={date.ToDeLijnDateOnlyString(true)}";

    internal static string GetStopsForLineDirection(int entityId, int lineId, Direction lineDirection, DateTimeOffset? date) =>
        $"{GetAllLines}/{entityId}/{lineId}/lijnrichtingen/{lineDirection.ToTranslatedString()}/haltes?geldigOp={date.ToDeLijnDateTimeOffsetString(true)}";

    internal static string GetDiversionsForLineDirection(int entityId, int lineId, Direction lineDirection, DateTimeOffset? date) =>
        $"{GetAllLines}/{entityId}/{lineId}/lijnrichtingen/{lineDirection.ToTranslatedString()}/omleidingen?datum={date.ToDeLijnDateOnlyString(true)}"; 

    internal static string GetRealTimeForLineDirection(int entityId, int lineId, Direction lineDirection) =>
        $"{GetAllLines}/{entityId}/{lineId}/lijnrichtingen/{lineDirection.ToTranslatedString()}/real-time";

    internal static string GetDrivesForLineDirection(int entityId, int lineId, Direction lineDirection, int driveId, DateTimeOffset? date) =>
        $"{GetAllLines}/{entityId}/{lineId}/lijnrichtingen/{lineDirection.ToTranslatedString()}/rit/{driveId}?datum={date.ToDeLijnDateOnlyString(true)}"; 

    internal static string GetDisruptionsForLineDirection(int entityId, int lineId, Direction lineDirection, int driveId, DateTimeOffset? date) =>
        $"{GetAllLines}/{entityId}/{lineId}/lijnrichtingen/{lineDirection.ToTranslatedString()}/storingen?datum={date.ToDeLijnDateOnlyString(true)}";
        
}