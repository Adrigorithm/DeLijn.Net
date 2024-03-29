using System.Net.Http.Headers;
using System.Text.Json;
using Delijn.Net.Entities;
using Delijn.Net.Entities.Response;
using DeLijn.Net.Api.Client.Config;
using DeLijn.Net.Api.Static;
using DeLijn.Net.Entities;
using DeLijn.Net.Entities.Response;

namespace DeLijn.Net.Api.Client;

/// <summary>
/// Create a REST client to make DeLijnAPI calls.
/// </summary>
/// <param name="httpClientFactory">Use the DI container to inject this or leave null to allow the client to create a HttpClient singleton</param>
public sealed partial class DeLijnClient(DeLijnConfig _config, IHttpClientFactory? httpClientFactory = null) : BaseClient(_config, httpClientFactory)
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
    /// Get all entities
    /// </summary>
    /// <returns>A list of entity objects</returns>
    /// <exception cref="HttpRequestException"></exception>
    public async Task<IReadOnlyList<Entity>> GetAllEntitiesAsync(CancellationToken? cancellationToken = null)
    {
        var responseBody = await GetAsync<EntitiesResponse>(ApiEndpoints.GetAllEntities, cancellationToken);

        return responseBody.Entities;
    }

    public async Task<(IReadOnlyList<Diversion> diversions, IReadOnlyList<Diversion> faults)> GetDiversionsAsync(DateTimeOffset? startDate = null, DateTimeOffset? endDate = null, CancellationToken? cancellationToken = null)
    {
        var responseBody = await GetAsync<DiversionsResponse>(ApiEndpoints.GetDiversions(startDate, endDate), cancellationToken);

        return (responseBody.Diversions, responseBody.Faults);
    }

    public async Task<(IReadOnlyList<Diversion> diversions, IReadOnlyList<Diversion> faults)> GetDiversionsByStopAsync(int entityId, int stopId, DateTimeOffset? date = null, CancellationToken? cancellationToken = null)
    {
        var responseBody = await GetAsync<DiversionsResponse>(ApiEndpoints.GetDiversionsByStop(entityId, stopId, date), cancellationToken);

        return (responseBody.Diversions, responseBody.Faults);
    }

    public async Task<(IReadOnlyList<StopArrival> stopArrivals, IReadOnlyList<Note> arrivalNotes, IReadOnlyList<Note> rideNotes, IReadOnlyList<Note> diversions)> GetTimetableForStopAsync(int entityId, int stopId, DateTimeOffset? date, CancellationToken? cancellationToken = null)
    {
        var responseBody = await GetAsync<ArrivalsResponse>(ApiEndpoints.GetTimetableForStop(entityId, stopId, date), cancellationToken);

        return (responseBody.StopArrivals, responseBody.ArrivalNotes, responseBody.RideNotes, responseBody.Diversions);
    }

    public async Task<IReadOnlyList<LineDirection>> GetLineDirectionsForStopAsync(int entityId, int stopId, DateTimeOffset? date, CancellationToken? cancellationToken = null)
    {
        var responseBody = await GetAsync<LineDirectionsResponse>(ApiEndpoints.GetLineDirectionsForStop(entityId, stopId, date), cancellationToken);

        return responseBody.LineDirections;
    }

    public async Task<IReadOnlyList<StopPoint>> GetStopPointsNearCoordinateAsync(GeoCoordinate coordinate, int? maxResults, int? radius, CancellationToken? cancellationToken = null)
    {
        var responseBody = await GetAsync<StopPointsResponse>(ApiEndpoints.GetStopPointsNearCoordinate(coordinate, maxResults, radius), cancellationToken);

        return responseBody.StopPoints;
    }

    public async Task<IReadOnlyList<Stop>> GetStopsBulkAsync(IEnumerable<int> stopIds, DateTimeOffset? validOnDate, CancellationToken? cancellationToken = null)
    {
        var responseBody = await GetAsync<StopsResponse>(ApiEndpoints.GetStopsByKeys(stopIds, validOnDate), cancellationToken);

        return responseBody.Stops;
    }

    public async Task<(IReadOnlyList<StopArrival> stopArrivals, IReadOnlyList<Note> arrivalNotes, IReadOnlyList<Note> rideNotes, IReadOnlyList<Note> diversions)> GetTimetableForStopKeysAsync(IEnumerable<int> stopIds, DateTimeOffset? date, CancellationToken? cancellationToken = null)
    {
        var responseBody = await GetAsync<ArrivalsResponse>(ApiEndpoints.GetTimetableForStopKeys(stopIds, date), cancellationToken);

        return (responseBody.StopArrivals, responseBody.ArrivalNotes, responseBody.RideNotes, responseBody.Diversions);
    }

    private async Task<T> GetAsync<T>(string requestUri, CancellationToken? token)
    {
        var httpClient = HttpClient;

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