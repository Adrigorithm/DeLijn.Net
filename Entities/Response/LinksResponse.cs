using System.Text.Json.Serialization;

namespace DeLijn.Net.Entities.Response;

internal record LinksResponse(
    [property: JsonPropertyName("links")] IReadOnlyList<Link> Links
);