using System.Net.Http.Headers;

namespace DeLijn.Net.Api.Client;

public abstract class BaseClient
{
    protected HttpClient HttpClient;

    protected BaseClient(string baseUri)
    {
        HttpClient = new()
        {
            BaseAddress = new Uri(baseUri)
        };

        HttpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "token here");
        HttpClient.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue
        {
            NoCache = true
        };
    }
}