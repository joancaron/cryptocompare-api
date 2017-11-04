using System;

namespace CryptoCompare.Core
{
    internal static class ApiUrls
    {
        public static readonly Uri MinApiEndpoint = new Uri("https://min-api.cryptocompare.com/api/data/", UriKind.Absolute);
        public static readonly Uri SiteApiEndpoint = new Uri("https://www.cryptocompare.com/api/data/", UriKind.Absolute);
    }
}
