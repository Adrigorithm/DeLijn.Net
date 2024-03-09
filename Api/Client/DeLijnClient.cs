using System.Text.Json;
using DeLijn.Net.Entities;
using DeLijn.Net.Entities.Response;

namespace DeLijn.Net.Api.Client;

public sealed class DeLijnClient : BaseClient
{
    /// <summary>
    /// Get all core endpoints of DeLijnAPI.
    /// </summary>
    /// <returns>A list of links representing endpoints</returns>
    /// <exception cref="HttpRequestException"></exception>
    [Obsolete("For matching the API endpoints. (You shouldn't use this, it has no use)", false)]
    public async Task<IReadOnlyList<Link>> GetCoreEndpoints()
    {
        var requestUri = ApiEndpoints.GetAPIEndpoints;
        var responseBody = await JsonSerializer.DeserializeAsync<LinksResponse>(await HttpClient.GetStreamAsync(new Uri(requestUri)));
        
        return responseBody is null
            ? throw new HttpRequestException($"Couldn't request GET {requestUri}")
            : responseBody.Links;
    }

    /// <summary>
    /// Get all lines for a specific entity
    /// </summary>
    /// <param name="entityId">Entity to filter on</param>
    /// <param name="validOn">Date on which all lines should be valid, is ignored if entityId is not set</param>
    /// <returns>A list of line objects</returns>
    /// <exception cref="HttpRequestException"></exception>
    public async Task<IReadOnlyList<Line>> GetLinesByEntity(int? entityId, DateOnly? validOn = null)
    {
        var requestUri = entityId is null 
            ? ApiEndpoints.GetAllLines 
            : ApiEndpoints.GetLinesByEntity((int)entityId, validOn);

        var responseBody = await JsonSerializer.DeserializeAsync<LinesResponse>(await HttpClient.GetStreamAsync(new Uri(requestUri)));
        
        return responseBody is null
            ? throw new HttpRequestException($"Couldn't request GET {requestUri}")
            : responseBody.Lines;
    }

    /// <summary>
    /// Get all entities
    /// </summary>
    /// <returns>A list of entity objects</returns>
    /// <exception cref="HttpRequestException"></exception>
    public async Task<IReadOnlyList<Entity>> GetAllEntities()
    {
        var requestUri = ApiEndpoints.GetAllEntities;
        var responseBody = await JsonSerializer.DeserializeAsync<EntitiesResponse>(await HttpClient.GetStreamAsync(new Uri(requestUri)));

        return responseBody is null
            ? throw new HttpRequestException($"Couldn't request GET {requestUri}")
            : responseBody.Entities;
    }
}