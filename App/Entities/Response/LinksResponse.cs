using System.Text.Json.Serialization;

namespace DeLijn.Net.App.Entities.Response;

internal record LinksResponse(
    [property: JsonPropertyName("links")] IReadOnlyList<Link> Links
);