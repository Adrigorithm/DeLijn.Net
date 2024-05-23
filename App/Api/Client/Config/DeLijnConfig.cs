using System.Text.Json;

namespace DeLijn.Net.Api.Client.Config;

public class DeLijnConfig
{
    public string DeLijnPrimaryKey { get; private set; }
    public string? DeLijnSecondaryKey { get; private set; }

    public DeLijnConfig(string deLijnPrimaryKey, string? deLijnSecondaryKey) =>
        (DeLijnPrimaryKey, DeLijnSecondaryKey) = (deLijnPrimaryKey, deLijnSecondaryKey);

    /// <summary>
    /// Creates a configuration object using values loaded from the stream
    /// </summary>
    /// <param name="ioStream">The stream to load bytes from</param>
    /// <returns>A configured DeLijnConfig instance or null if it could not be loaded</returns>
    public static DeLijnConfig? FromStream(Stream ioStream)
    {
        try
        {
            var parsedConfig = JsonSerializer.Deserialize<DeLijnConfig>(ioStream);
            return parsedConfig;
        }
        catch
        {
            return null;
        }
    }
}