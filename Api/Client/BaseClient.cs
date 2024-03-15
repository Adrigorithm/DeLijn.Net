using System.Net.Http.Headers;

namespace DeLijn.Net.Api.Client;

public abstract class BaseClient
{
    protected IHttpClientFactory? HttpClientFactory;
    protected HttpClient? HttpClient;

    protected BaseClient(IHttpClientFactory? httpClientFactory = null)
    {
        if (httpClientFactory is null)
        {
            HttpClient = new();
            HttpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "token here");
            HttpClient.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue
            {
                NoCache = true
            };
        }
        else
            HttpClientFactory = httpClientFactory;
    }
}