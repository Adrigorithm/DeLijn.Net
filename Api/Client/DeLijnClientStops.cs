using System.Text.Json;
using Delijn.Net.Entities;
using Delijn.Net.Entities.Response;
using DeLijn.Net.Api.Static;
using DeLijn.Net.Entities;
using DeLijn.Net.Entities.Response;

namespace DeLijn.Net.Api.Client;

public sealed partial class DeLijnClient : BaseClient
{
    public async Task<IReadOnlyList<Stop>> GetStopsByEntityAsync(int entityId)
    {
        var responseBody = await GetAsync<StopsResponse>(ApiEndpoints.GetStopsByEntity(entityId));

        return responseBody.Stops;
    }
}