using System.Text.Json.Serialization;

namespace DeLijn.Net.App.Entities.Response;

public record Link(
    [property: JsonPropertyName("rel")] string Rel,
    [property: JsonPropertyName("url")] string Url
);