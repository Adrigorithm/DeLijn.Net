namespace DeLijn.Net.Api.Helpers.Extensions;

internal static class DateTimeOffsetExtensions
{
    public static string ToDateTimeString(this DateTimeOffset? dateTimeOffset) =>
        dateTimeOffset is null
            ? throw new NotImplementedException()
            : dateTimeOffset.Value.ToString("yyyy-MM-ddTHH:mm:ss");
}
