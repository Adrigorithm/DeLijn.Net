using System.Text.Json;
using DeLijn.Net.App.Entities;
using DeLijn.Net.App.Entities.Response;
using DeLijn.Net.App.Api.Static;
using DeLijn.Net.App.Api.Client;

namespace DeLijn.Net.App.Api.Client;

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

    public async Task<IReadOnlyList<Municipality>> GetMunicipalitiesByEntityAsync(short entityId, CancellationToken? cancellationToken = null)
    {
        var responseBody = await GetAsync<MunicipalitiesResponse>(ApiEndpoints.GetMunicipalitiesByEntity(entityId), cancellationToken);

        return responseBody.Municipalities;
    }

    public async Task<Municipality> GetMunicipalityById(short id, CancellationToken? cancellationToken = null)
    {
        var responseBody = await GetAsync<Municipality>(ApiEndpoints.GetMunicipalityById(id), cancellationToken);

        return responseBody;
    }
}