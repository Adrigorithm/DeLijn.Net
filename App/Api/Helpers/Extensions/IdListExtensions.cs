using System.Text;

namespace DeLijn.Net.App.Api.Helpers.Extensions;

internal static class IdListExtensions
{
    internal static string ToStopIdUrlParamList(this IEnumerable<int> stopIds)
    {
        if (stopIds.Count() == 0)
            return string.Empty;

        var urlParamBuilder = new StringBuilder();
        urlParamBuilder.Append($"1_{stopIds.First()}");

        for (int i = 1; i < stopIds.Count(); i++)
            urlParamBuilder.Append($"_1_{stopIds.ElementAt(i)}");

        return urlParamBuilder.ToString();
    }
}
