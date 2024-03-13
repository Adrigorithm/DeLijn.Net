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
    public async Task<IReadOnlyList<Municipality>> GetAllMunicipalitiesAsync()
    {
        var responseBody = await GetAsync<MunicipalitiesResponse>(ApiEndpoints.GetAllMunicipalities);

        return responseBody.Municipalities;
    }

    public async Task<IReadOnlyList<Municipality>> GetMunicipalitiesByEntityAsync(int entityId)
    {
        var requestUri = ApiEndpoints.GetMunicipalitiesByEntity(entityId);

        var responseBody = await JsonSerializer.DeserializeAsync<MunicipalitiesResponse>(await HttpClient.GetStreamAsync(new Uri(requestUri)));

        return responseBody is null
            ? throw new HttpRequestException($"Couldn't request GET {requestUri}")
            : responseBody.Municipalities;
    }
}