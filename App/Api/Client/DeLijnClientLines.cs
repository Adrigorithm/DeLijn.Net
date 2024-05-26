using DeLijn.Net.App.Entities;
using DeLijn.Net.App.Entities.Response;
using DeLijn.Net.App.Api.Static;

namespace DeLijn.Net.App.Api.Client;

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
    /// <param name="validOn">Date on which all lines should be valid, is ignored if null</param>
    /// <returns>A list of line objects</returns>
    /// <exception cref="HttpRequestException"></exception>
    public async Task<IReadOnlyList<Line>> GetLinesByEntityAsync(int entityId, DateTimeOffset? validOn = null, CancellationToken? cancellationToken = null)
    {
        var responseBody = await GetAsync<LinesResponse>(ApiEndpoints.GetLinesByEntity((int)entityId, validOn), cancellationToken);

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

    public async Task<IReadOnlyList<Line>> GetLinesByMunicipalityAsync(int municipalityId, CancellationToken? cancellationToken)
    {
        var responseBody = await GetAsync<LinesResponse>(ApiEndpoints.GetLinesByMunicipality(municipalityId), cancellationToken);

        return responseBody.Lines;
    }
}