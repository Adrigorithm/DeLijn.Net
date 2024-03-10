using Delijn.Net.Api.Helpers.Attributes;

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

    [Useless("Doesn't actually return any stops, it exists for nothing")]
    internal static string GetAllStops =>
        BaseUri + "haltes";

    internal static string GetStopsByMunicipality(int municipalityId) =>
        $"{BaseUri}gemeenten/{municipalityId}/haltes";

    internal static string GetStopsByEntity(int entityId) =>
        $"{BaseUri}entiteiten/{entityId}/haltes";

    internal static string GetAllLines =>
        BaseUri + "lijnen";

    /// <summary>
    /// return all lines currently or in the future valid for the requested entity
    /// </summary>
    /// <param name="entityId">filter by entity</param>
    /// <param name="validOnDate">filter by a date on which all returned lines should be valid</param>
    internal static string GetLinesByEntity(int entityId, DateOnly? validOnDate) =>
        $"{BaseUri}entiteiten/{entityId}/lijnen{(validOnDate is null ? "" : $"?geldigOp={((DateOnly)validOnDate).ToString("yyyy-MM-dd")}")}";

    internal static string GetLinesByMunicipality(int municipalityId) =>
        $"{BaseUri}gemeenten/{municipalityId}/lijnen";

    internal static string GetAllColours =>
        BaseUri + "kleuren";

    internal static string GetTimetableForStop(int entityId, int stopId, DateTime? date) =>
        $"{BaseUri}haltes/{entityId}/{stopId}/dienstregelingen{(date is null ? "" : $"?{((DateTime)date).ToString("yyyy-MM-dd")}")}";

    internal static string GetTimetableForStopkeys(string stopKeys, DateTime? date) =>
        $"{BaseUri}haltes/{stopKeys}/dienstregelingen{(date is null ? "" : $"?{((DateTime)date).ToString("yyyy-MM-dd")}")}";
}