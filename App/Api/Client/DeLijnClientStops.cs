using System.Text.Json;
using Delijn.Net.Api.Helpers.Attributes;
using Delijn.Net.Entities;
using Delijn.Net.Entities.Response;
using DeLijn.Net.Api.Static;
using DeLijn.Net.Entities;
using DeLijn.Net.Entities.Response;

namespace DeLijn.Net.Api.Client;

public sealed partial class DeLijnClient : BaseClient
{
    public async Task<IReadOnlyList<Stop>> GetStopsByEntityAsync(int entityId, CancellationToken? cancellationToken = null)
    {
        var responseBody = await GetAsync<StopsResponse>(ApiEndpoints.GetStopsByEntity(entityId), cancellationToken);

        return responseBody.Stops;
    }

    public async Task<IReadOnlyList<Stop>> GetStopsByMunicipalityAsync(int municipalityId, CancellationToken? cancellationToken = null)
    {
        var responseBody = await GetAsync<StopsResponse>(ApiEndpoints.GetStopsByMunicipality(municipalityId), cancellationToken);

        return responseBody.Stops;
    }

    [Useless("Doesn't actually return any stops, it exists for nothing")]
    public async Task<IReadOnlyList<Stop>> GetAllStops(CancellationToken? cancellationToken = null)
    {
        var responseBody = await GetAsync<StopsResponse>(ApiEndpoints.GetAllStops, cancellationToken);

        return responseBody.Stops;
    }

    public async Task<Stop> GetStopAsync(int entityId, int stopId, DateTimeOffset? validOn, CancellationToken? cancellationToken = null)
    {
        var responseBody = await GetAsync<Stop>(ApiEndpoints.GetStop(entityId, stopId, validOn), cancellationToken);

        return responseBody;
    }
}