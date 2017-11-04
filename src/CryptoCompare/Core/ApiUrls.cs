using System;

namespace CryptoCompare.Core
{
    internal static class ApiUrls
    {
        private const string RateLimitsUrl = "/stats/rate/{0}/limit";

        public static readonly Uri MinApiEndpoint = new Uri(
            "https://min-api.cryptocompare.com/data/",
            UriKind.Absolute);

        public static readonly Uri SiteApiEndpoint = new Uri(
            "https://www.cryptocompare.com/api/data/",
            UriKind.Absolute);

        public static Uri AllCoins => new Uri(MinApiEndpoint, "all/coinlist");

        public static Uri AllExchanges => new Uri(MinApiEndpoint, "all/exchanges");

        public static Uri RateLimitsByHour => new Uri(MinApiEndpoint, string.Format(RateLimitsUrl, "hour"));

        public static Uri RateLimitsByMinute => new Uri(MinApiEndpoint, string.Format(RateLimitsUrl, "minute"));

        public static Uri RateLimitsBySecond => new Uri(MinApiEndpoint, string.Format(RateLimitsUrl, "second"));
    }
}
