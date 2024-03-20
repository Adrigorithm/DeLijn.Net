using System.Text;

namespace DeLijn.Net.Api.Helpers.Extensions;

internal static class IdListExtensions
{
    internal static string ToStopIdUrlParamList(this int[] stopIds)
    {
        if (stopIds.Length == 0)
            return string.Empty;

        var urlParamBuilder = new StringBuilder();
        urlParamBuilder.Append($"1_{stopIds[0]}");
        
        for (int i = 1; i < stopIds.Length; i++)
            urlParamBuilder.Append($"_1_{stopIds[i]}");

        return urlParamBuilder.ToString();
    }
}
