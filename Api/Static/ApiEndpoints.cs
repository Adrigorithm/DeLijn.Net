using System.Text.Json;
using Delijn.Net.Api.Helpers.Attributes;
using DeLijn.Net.Api.Helpers.Extensions;

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
        $"{GetAllStops}/{entityId}/{stopId}/real-time?maxAantalDoorkomsten={maxResults?.ToString() ?? string.Empty}";
    
    // internal static string GetAllLines =>
    //     $"{BaseUri}lijnen";
    
    // internal static string GetAllLines =>
    //     $"{BaseUri}lijnen";
    
    // internal static string GetAllLines =>
    //     $"{BaseUri}lijnen";
    
    // internal static string GetAllLines =>
    //     $"{BaseUri}lijnen";
    
    // internal static string GetAllLines =>
    //     $"{BaseUri}lijnen";
    
    // internal static string GetAllLines =>
    //     $"{BaseUri}lijnen";
    
    // internal static string GetAllLines =>
    //     $"{BaseUri}lijnen";
    
    // internal static string GetAllLines =>
    //     $"{BaseUri}lijnen";
    
    // internal static string GetAllLines =>
    //     $"{BaseUri}lijnen";
    
    // internal static string GetAllLines =>
    //     $"{BaseUri}lijnen";
    
    // internal static string GetAllLines =>
    //     $"{BaseUri}lijnen";
    
    // internal static string GetAllLines =>
    //     $"{BaseUri}lijnen";
    
    // internal static string GetAllLines =>
    //     $"{BaseUri}lijnen";
    
    // internal static string GetAllLines =>
    //     $"{BaseUri}lijnen";
    
}