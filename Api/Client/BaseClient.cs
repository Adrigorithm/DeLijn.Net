using System.Net.Http.Headers;

namespace DeLijn.Net.Api.Client;

public abstract class BaseClient
{
    protected HttpClient HttpClient;

    protected BaseClient(HttpClient? httpClient)
    {
        HttpClient = httpClient ?? new();

        HttpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "token here");
        HttpClient.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue
        {
            NoCache = true
        };
    }
}