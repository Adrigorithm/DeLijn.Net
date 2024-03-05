internal static class ApiEndpoints
{
    private const string baseUri = "https://api.delijn.be/DLKernOpenData/v1/beta/";
    
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
    
    internal static string GetTimetableOfStop(int stopId) =>
        $"{baseUri}haltes/{entiteitnummer}/{haltenummer}/dienstregelingen[?datum]"