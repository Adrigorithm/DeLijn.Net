using System.Text.Json;
using DeLijn.Net.entities;

namespace DeLijn.Net.api.client;

public sealed class DeLijnClient(string baseUri = "https://api.delijn.be/DLKernOpenData/v1/beta/") : BaseClient(baseUri)
{
    public async Task<(IReadOnlyList<Entity> entities, IReadOnlyList<Link> links)> GetAllEntitiesAsync()
    {
        var responseBody = await JsonSerializer.DeserializeAsync<GetAllEntities>(await HttpClient.GetStreamAsync(new Uri("entiteiten")));
        
        return responseBody is null
            ? throw new HttpRequestException($"Couldn't request GET {baseUri}enteiten")
            : (responseBody.Entities, responseBody.Links);
    }
}