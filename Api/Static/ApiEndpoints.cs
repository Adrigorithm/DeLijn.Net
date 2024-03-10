internal static class ApiEndpoints
{
    private const string baseUri = "https://api.delijn.be/DLKernOpenData/api/v1/";

    internal static string GetAPIEndpoints =>
        $"{baseUri}api";

    internal static string GetAllEntities =>
        baseUri + "entiteiten";

    internal static string GetAllMunicipalities =>
        baseUri + "gemeenten";

    internal static string GetMunicipalitiesByEntity(int entityId) =>
        $"{baseUri}entiteiten/{entityId}/gemeenten";

    internal static string GetAllStops =>
        baseUri + "haltes";

    internal static string GetStopsByMunicipality(int municipalityId) =>
        $"{baseUri}gemeenten/{municipalityId}/haltes";

    internal static string GetStopsByEntity(int entityId) =>
        $"{baseUri}entiteiten/{entityId}/haltes";

    internal static string GetAllLines =>
        baseUri + "lijnen";

    /// <summary>
    /// return all lines currently or in the future valid for the requested entity
    /// </summary>
    /// <param name="entityId">filter by entity</param>
    /// <param name="validOnDate">filter by a date on which all returned lines should be valid</param>
    internal static string GetLinesByEntity(int entityId, DateOnly? validOnDate) =>
        $"{baseUri}entiteiten/{entityId}/lijnen{(validOnDate is null ? "" : $"?geldigOp={((DateOnly)validOnDate).ToString("yyyy-MM-dd")}")}";

    internal static string GetLinesByMunicipality(int municipalityId) =>
        $"{baseUri}gemeenten/{municipalityId}/lijnen";

    internal static string GetAllLineColours =>
        baseUri + "kleuren";

    internal static string GetTimetableForStop(int entityId, int stopId, DateTime? date) =>
        $"{baseUri}haltes/{entityId}/{stopId}/dienstregelingen{(date is null ? "" : $"?{((DateTime)date).ToString("yyyy-MM-dd")}")}";

    internal static string GetTimetableForStopkeys(string stopKeys, DateTime? date) =>
        $"{baseUri}haltes/{stopKeys}/dienstregelingen{(date is null ? "" : $"?{((DateTime)date).ToString("yyyy-MM-dd")}")}";
}