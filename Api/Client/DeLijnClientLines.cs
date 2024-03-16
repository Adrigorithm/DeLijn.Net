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
public sealed partial class DeLijnClient : BaseClient
{
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
    /// Get all lines
    /// </summary>
    /// <returns>A list of line objects</returns>
    /// <exception cref="HttpRequestException"></exception>
    public async Task<IReadOnlyList<Line>> GetAllLinesAsync(CancellationToken? cancellationToken)
    {
        var responseBody = await GetAsync<LinesResponse>(ApiEndpoints.GetAllLines, cancellationToken);

        return responseBody.Lines;
    }
}