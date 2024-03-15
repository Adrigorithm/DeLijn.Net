using System.Net.Http.Headers;
using System.Text.Json;
using Delijn.Net.Entities;
using Delijn.Net.Entities.Response;
using DeLijn.Net.Api.Static;
using DeLijn.Net.Entities;
using DeLijn.Net.Entities.Response;

namespace DeLijn.Net.Api.Client;

/// <summary>
/// Create a REST client to make DeLijnAPI calls.
/// </summary>
/// <param name="httpClientFactory">Use the DI container to inject this or leave null to allow the client to create a HttpClient singleton</param>
public sealed partial class DeLijnClient(IHttpClientFactory? httpClientFactory = null) : BaseClient(httpClientFactory)
{
    /// <summary>
    /// Get all core endpoints of DeLijnAPI.
    /// </summary>
    /// <returns>A list of links representing endpoints</returns>
    /// <exception cref="HttpRequestException"></exception>
    [Obsolete("For matching the API endpoints. (You shouldn't use this, it has no use)", false)]
    public async Task<IReadOnlyList<Link>> GetCoreEndpointsAsync(CancellationToken? cancellationToken = null)
    {
        var responseBody = await GetAsync<LinksResponse>(ApiEndpoints.GetAPIEndpoints, cancellationToken);

        return responseBody.Links;
    }

    /// <summary>
    /// Get all lines for a specific entity
    /// </summary>
    /// <param name="entityId">Entity to filter on</param>
    /// <param name="validOn">Date on which all lines should be valid, is ignored if entityId is not set</param>
    /// <returns>A list of line objects</returns>
    /// <exception cref="HttpRequestException"></exception>
    public async Task<IReadOnlyList<Line>> GetLinesAsync(int? entityId, DateOnly? validOn = null, CancellationToken? cancellationToken = null)
    {
        var requestUri = entityId is null
            ? ApiEndpoints.GetAllLines
            : ApiEndpoints.GetLinesByEntity((int)entityId, validOn);

        var responseBody = await GetAsync<LinesResponse>(requestUri, cancellationToken);

        return responseBody.Lines;
    }

    /// <summary>
    /// Get all entities
    /// </summary>
    /// <returns>A list of entity objects</returns>
    /// <exception cref="HttpRequestException"></exception>
    public async Task<IReadOnlyList<Entity>> GetAllEntitiesAsync(CancellationToken? cancellationToken = null)
    {
        var responseBody = await GetAsync<EntitiesResponse>(ApiEndpoints.GetAllEntities, cancellationToken);

        return responseBody.Entities;
    }

    /// <summary>
    /// Get all lines
    /// </summary>
    /// <returns>A list of line objects</returns>
    /// <exception cref="HttpRequestException"></exception>
    public async Task<IReadOnlyList<Line>> GetAllLinesAsync(CancellationToken? cancellationToken)
    {
        var responseBody = await GetAsync<LinesResponse>(ApiEndpoints.GetAllLines, cancellationToken);

        return responseBody.Lines;
    }

    public async Task<(IReadOnlyList<Diversion> diversions, IReadOnlyList<Diversion> faults)> GetDiversionsAsync(DateTimeOffset? startDate = null, DateTimeOffset? endDate = null, CancellationToken? cancellationToken = null)
    {
        var responseBody = await GetAsync<DiversionsResponse>(ApiEndpoints.GetDiversions(startDate, endDate), cancellationToken);

        return (responseBody.Diversions, responseBody.Faults);
    }

    private async Task<T> GetAsync<T>(string requestUri, CancellationToken? token)
    {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
        HttpClient httpClient = HttpClient;
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

        if (httpClient is null)
        {
            httpClient = HttpClientFactory!.CreateClient();
            httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "token here");
            httpClient.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue
            {
                NoCache = true
            };
        }

        var responseBody = await JsonSerializer.DeserializeAsync<T>(token is null
            ? await httpClient.GetStreamAsync(new Uri(requestUri))
            : await httpClient.GetStreamAsync(new Uri(requestUri), (CancellationToken)token));

        return responseBody is null
            ? throw new HttpRequestException($"Couldn't request GET {requestUri}")
            : responseBody;
    }
}