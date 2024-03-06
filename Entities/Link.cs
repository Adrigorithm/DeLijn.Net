using System.Text.Json.Serialization;

namespace DeLijn.Net.Entities.Response;

internal record Link(
    [property: JsonPropertyName("rel")] string Rel,
    [property: JsonPropertyName("url")] string Url
);