using System.Text.Json;
using DeLijn.Net.entities;

namespace DeLijn.Net.api.client;

public sealed class DeLijnClient(string baseUri = "https://api.delijn.be/DLKernOpenData/v1/beta/") : BaseClient(baseUri)
{
    public async Task<(IReadOnlyList<Entity>, IReadOnlyList<Link>)> GetAllEntitiesAsync() =>
        await JsonSerializer.DeserializeAsync<(IReadOnlyList<Entity>, IReadOnlyList<Link>)>(await HttpClient.GetStreamAsync(new Uri("entiteiten")));
}