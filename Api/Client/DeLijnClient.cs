using System.Text.Json;
using Delijn.Net.Entities;
using Delijn.Net.Entities.Response;
using DeLijn.Net.Api.Static;
using DeLijn.Net.Entities;
using DeLijn.Net.Entities.Response;

namespace DeLijn.Net.Api.Client;

public sealed partial class DeLijnClient : BaseClient
{
    /// <summary>
    /// Get all core endpoints of DeLijnAPI.
    /// </summary>
    /// <returns>A list of links representing endpoints</returns>
    /// <exception cref="HttpRequestException"></exception>
    [Obsolete("For matching the API endpoints. (You shouldn't use this, it has no use)", false)]
    public async Task<IReadOnlyList<Link>> GetCoreEndpointsAsync()
    {
        var responseBody = await GetAsync<LinksResponse>(ApiEndpoints.GetAPIEndpoints);

        return responseBody.Links;
    }

    /// <summary>
    /// Get all lines for a specific entity
    /// </summary>
    /// <param name="entityId">Entity to filter on</param>
    /// <param name="validOn">Date on which all lines should be valid, is ignored if entityId is not set</param>
    /// <returns>A list of line objects</returns>
    /// <exception cref="HttpRequestException"></exception>
    public async Task<IReadOnlyList<Line>> GetLinesByEntityAsync(int? entityId, DateOnly? validOn = null)
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
    public async Task<IReadOnlyList<Entity>> GetAllEntitiesAsync()
    {
        var responseBody = await GetAsync<EntitiesResponse>(ApiEndpoints.GetAllEntities);

        return responseBody.Entities;
    }

    /// <summary>
    /// Get all lines
    /// </summary>
    /// <returns>A list of line objects</returns>
    /// <exception cref="HttpRequestException"></exception>
    public async Task<IReadOnlyList<Line>> GetAllLinesAsync()
    {
        var responseBody = await GetAsync<LinesResponse>(ApiEndpoints.GetAllLines);

        return responseBody.Lines;
    }

    public async Task<(IReadOnlyList<Diversion> diversions, IReadOnlyList<Diversion> faults)> GetDiversions(DateTimeOffset? startDate = null, DateTimeOffset? endDate = null)
    {
        var responseBody = await GetAsync<DiversionsResponse>(ApiEndpoints.GetDiversions(startDate, endDate));

        return (responseBody.Diversions, responseBody.Faults);
    }

    private async Task<T> GetAsync<T>(string requestUri)
    {
        var responseBody = await JsonSerializer.DeserializeAsync<T>(await HttpClient.GetStreamAsync(new Uri(requestUri)));

        return responseBody is null
            ? throw new HttpRequestException($"Couldn't request GET {requestUri}")
            : responseBody;
    }
}