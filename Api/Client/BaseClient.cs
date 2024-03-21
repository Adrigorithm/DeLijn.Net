using System.Net.Http.Headers;
using DeLijn.Net.Api.Client.Config;

namespace DeLijn.Net.Api.Client;

public abstract class BaseClient
{
    protected IHttpClientFactory? HttpClientFactory;
    protected HttpClient? HttpClient;
    protected DeLijnConfig? ClientConfig;

    protected BaseClient(DeLijnConfig? deLijnConfig, IHttpClientFactory? httpClientFactory = null)
    {
        ClientConfig = deLijnConfig;

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