using System.Text.Json.Serialization;

namespace DeLijn.Net.entities;

public record Link(
        [property: JsonPropertyName("rel")] string Rel,
        [property: JsonPropertyName("url")] string Url
    );