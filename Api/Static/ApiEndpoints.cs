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
        BaseUri + "entiteiten";

    internal static string GetAllMunicipalities =>
        BaseUri + "gemeenten";

    internal static string GetMunicipalitiesByEntity(int entityId) =>
        $"{BaseUri}entiteiten/{entityId}/gemeenten";

    internal static string GetStop(int entityId, int stopId, DateTimeOffset? validOnDate) =>
        $"{BaseUri}haltes/{entityId}/{stopId}{(validOnDate is null ? "" : $"?geldigOp={((DateTimeOffset)validOnDate).ToDeLijnDateTimeOffsetString(true)}")}";

    internal static string GetAllStops =>
        $"{BaseUri}haltes";

    internal static string GetStopsByMunicipality(int municipalityId) =>
        $"{BaseUri}gemeenten/{municipalityId}/haltes";

    internal static string GetStopsByEntity(int entityId) =>
        $"{BaseUri}entiteiten/{entityId}/haltes";

    internal static string GetAllLines =>
        $"{BaseUri}lijnen";

    internal static string GetAllDiversions =>
        $"{BaseUri}omleidingen";

    internal static string GetDiversions(DateTimeOffset? startDate = null, DateTimeOffset? endDate = null)
    {
        var isParamAdded = false;
        var endpoint = GetAllDiversions;

        if (endDate is not null)
        {
            endpoint = $"{endpoint}?eindDatum={((DateTimeOffset)endDate).ToDeLijnDateTimeOffsetString(true)}";
            isParamAdded = true;
        }

        if (startDate is not null)
            endpoint = $"{endpoint}{(isParamAdded ? $"&startDatum={((DateTimeOffset)startDate).ToDeLijnDateTimeOffsetString(true)}" : $"?startDatum={((DateTimeOffset)startDate).ToDeLijnDateTimeOffsetString(true)}")}";

        return endpoint;
    }

    /// <summary>
    /// return all lines currently or in the future valid for the requested entity
    /// </summary>
    /// <param name="entityId">filter by entity</param>
    /// <param name="validOnDate">filter by a date on which all returned lines should be valid</param>
    internal static string GetLinesByEntity(int entityId, DateTimeOffset? validOnDate) =>
        $"{BaseUri}entiteiten/{entityId}/lijnen{(validOnDate is null ? "" : $"?geldigOp={((DateTimeOffset)validOnDate).ToDeLijnDateOnlyString(true)}")}";

    internal static string GetLinesByMunicipality(int municipalityId) =>
        $"{BaseUri}gemeenten/{municipalityId}/lijnen";

    internal static string GetMunicipalityById(int id) =>
        $"{BaseUri}gemeenten/{id}";

    internal static string GetTimetableForStop(int entityId, int stopId, DateTimeOffset? date) =>
        $"{BaseUri}haltes/{entityId}/{stopId}/dienstregelingen{(date is null ? "" : $"?datum={((DateTimeOffset)date).ToDeLijnDateOnlyString(true)}")}";
}