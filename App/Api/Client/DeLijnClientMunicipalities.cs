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
    /// Get all municipalities
    /// </summary>
    /// <returns>A list of municipality objects</returns>
    /// <exception cref="HttpRequestException"></exception>
    public async Task<IReadOnlyList<Municipality>> GetAllMunicipalitiesAsync(CancellationToken? cancellationToken = null)
    {
        var responseBody = await GetAsync<MunicipalitiesResponse>(ApiEndpoints.GetAllMunicipalities, cancellationToken);

        return responseBody.Municipalities;
    }

    public async Task<IReadOnlyList<Municipality>> GetMunicipalitiesByEntityAsync(int entityId, CancellationToken? cancellationToken = null)
    {
        var responseBody = await GetAsync<MunicipalitiesResponse>(ApiEndpoints.GetMunicipalitiesByEntity(entityId), cancellationToken);

        return responseBody.Municipalities;
    }

    public async Task<Municipality> GetMunicipalityById(int id, CancellationToken? cancellationToken = null)
    {
        var responseBody = await GetAsync<Municipality>(ApiEndpoints.GetMunicipalityById(id), cancellationToken);

        return responseBody;
    }
}