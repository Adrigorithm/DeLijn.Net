namespace DeLijn.Net.api.client;

public abstract class BaseClient
{
    protected HttpClient HttpClient;

    protected BaseClient(string baseUri)
    {
        HttpClient = new()
        {
            BaseAddress = new Uri(baseUri)
        };
    }
}