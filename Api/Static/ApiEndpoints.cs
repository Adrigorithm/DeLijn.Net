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

    internal static string GetLinesByEntity(int entityId) =>
        $"{baseUri}entiteiten/{entityId}/lijnen";
    
    internal static string GetLinesByMunicipality(int municipalityId) =>
        $"{baseUri}gemeenten/{municipalityId}/lijnen";

    internal static string GetAllLineColours =>
        baseUri + "kleuren";
    
    internal static string GetTimetableForStop(int entityId, int stopId, DateTime? date) =>
        $"{baseUri}haltes/{entityId}/{stopId}/dienstregelingen{(date is null ? "" : $"?{((DateTime)date).ToString("yyyy-MM-dd")}")}";

    /// <summary>
    /// Look inside :wires:
    /// </summary>
    /// <param name="stopKeys">Something weird</param>
    /// <param name="date"></param>
    /// <returns></returns>
    internal static string GetTimetableForStopkeys(string stopKeys, DateTime? date) =>
        $"{baseUri}haltes/{stopKeys}/dienstregelingen{(date is null ? "" : $"?{((DateTime)date).ToString("yyyy-MM-dd")}")}";
}