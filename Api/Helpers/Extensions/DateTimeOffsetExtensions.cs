namespace DeLijn.Net.Api.Helpers.Extensions;

/// <summary>
/// Utility class to convert DateTimeOffsets to formats used by DeLijnAPI
/// </summary>
internal static class DateTimeOffsetExtensions
{
    public static string ToDeLijnDateTimeOffsetString(this DateTimeOffset? dateTimeOffset, bool shouldBeConverted = false)
    {
        return dateTimeOffset is DateTimeOffset offsetNotNull
            ? shouldBeConverted
                ? offsetNotNull.ToDeLijnDateTimeOffset().ToString("yyyy-MM-ddTHH:mm:ss")
                : offsetNotNull.ToString("yyyy-MM-ddTHH:mm:ss")
            : string.Empty;
    }

    public static DateTimeOffset ToDeLijnDateTimeOffset(this DateTimeOffset dateTimeOffset) =>
        TimeZoneInfo.ConvertTimeBySystemTimeZoneId(dateTimeOffset, "Central European Standard Time");

    public static string ToDeLijnDateOnlyString(this DateTimeOffset? dateTimeOffset, bool shouldBeConverted = false)
    {
        return dateTimeOffset is DateTimeOffset offsetNotNull
            ? shouldBeConverted
                ? offsetNotNull.ToDeLijnDateTimeOffset().ToString("yyyy-MM-dd")
                : offsetNotNull.ToString("yyyy-MM-dd")
            : string.Empty;
    }
}
