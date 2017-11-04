using System;

namespace CryptoCompare.Core
{
    internal static class ApiUrls
    {
        public static readonly Uri MinApiEndpoint = new Uri("https://min-api.cryptocompare.com/api/data/", UriKind.Absolute);
        public static readonly Uri SiteApiEndpoint = new Uri("https://www.cryptocompare.com/api/data/", UriKind.Absolute);

        #region Rate Limits

        private const string RateLimitsUrl = "/stats/rate/{0}/limit";
        public static Uri RateLimitsByHour => new Uri(string.Format(RateLimitsUrl, "hour"), UriKind.Relative);
        public static Uri RateLimitsByMinute => new Uri(string.Format(RateLimitsUrl, "minute"), UriKind.Relative);
        public static Uri RateLimitsBySecond => new Uri(string.Format(RateLimitsUrl, "second"), UriKind.Relative);

        #endregion

    }
}
