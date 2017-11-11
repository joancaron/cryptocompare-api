using System;
using System.Collections.Generic;
using System.Globalization;

using JetBrains.Annotations;

namespace CryptoCompare
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

        public static Uri AllCoins() => new Uri(MinApiEndpoint, "all/coinlist");

        public static Uri AllExchanges() => new Uri(MinApiEndpoint, "all/exchanges");

        public static Uri CoinSnapshot([NotNull] string fsym, [NotNull] string tsym)
        {
            Check.NotNull(tsym, nameof(tsym));
            Check.NotNull(fsym, nameof(fsym));
            return new Uri(SiteApiEndpoint, "coinsnapshot").ApplyParameters(
                new Dictionary<string, string>()
                {
                    { nameof(fsym), fsym },
                    { nameof(tsym), tsym }
                });
        }

        public static Uri CoinSnapshotFull(int id)
        {
            return new Uri(SiteApiEndpoint, "coinsnapshotfullbyid").ApplyParameters(
                new Dictionary<string, string>()
                {
                    { nameof(id), id.ToString() }
                });
        }

        public static Uri History(
            string method,
            string fsym,
            string tsym,
            int? limit,
            IEnumerable<string> e,
            DateTimeOffset? toTs,
            bool? allData,
            int? aggregate,
            bool? tryConversion)
        {
            Check.NotNullOrWhiteSpace(fsym, nameof(fsym));
            Check.NotNullOrWhiteSpace(tsym, nameof(tsym));

            return new Uri(MinApiEndpoint, $"histo{method}").ApplyParameters(
                new Dictionary<string, string>()
                {
                    { nameof(fsym), fsym },
                    { nameof(tsym), tsym },
                    { nameof(limit), limit.ToString() },
                    { nameof(toTs), toTs?.ToUnixTime().ToString(CultureInfo.InvariantCulture) },
                    { nameof(tryConversion), tryConversion?.ToString() },
                    { nameof(e), e?.ToJoinedList() },
                    { nameof(allData), allData?.ToString() },
                    { nameof(aggregate), aggregate?.ToString() }
                });
        }

        public static Uri PriceAverage(
            [NotNull] string fsym,
            [NotNull] string tsym,
            [NotNull] IEnumerable<string> e,
            bool? tryConversion)
        {
            Check.NotNullOrWhiteSpace(fsym, nameof(fsym));
            Check.NotNullOrWhiteSpace(tsym, nameof(tsym));
            Check.NotEmpty(e, nameof(e));

            return new Uri(MinApiEndpoint, "generateAvg").ApplyParameters(
                new Dictionary<string, string>()
                {
                    { nameof(fsym), fsym },
                    { nameof(tsym), tsym },
                    { nameof(e), e.ToJoinedList() },
                    { nameof(tryConversion), tryConversion?.ToString() }
                });
        }

        public static Uri PriceHistorical(
            string fsym,
            IEnumerable<string> tsyms,
            DateTimeOffset ts,
            CalculationType? calculationType,
            bool? tryConversion,
            string e)
        {
            return new Uri(MinApiEndpoint, "pricehistorical").ApplyParameters(
                new Dictionary<string, string>()
                {
                    { nameof(fsym), fsym },
                    { nameof(tsyms), tsyms.ToJoinedList() },
                    {
                        nameof(ts),
                        ts.ToUnixTime().ToString(CultureInfo.InvariantCulture)
                    },
                    { nameof(calculationType), calculationType?.ToString("G") },
                    { nameof(tryConversion), tryConversion?.ToString() },
                    { nameof(e), e }
                });
        }

        public static Uri PriceMulti(
            [NotNull] IEnumerable<string> fsyms,
            [NotNull] IEnumerable<string> tsyms,
            bool? tryConversion,
            string e)
        {
            Check.NotEmpty(fsyms, nameof(fsyms));
            Check.NotEmpty(tsyms, nameof(tsyms));

            return new Uri(MinApiEndpoint, "pricemulti").ApplyParameters(
                new Dictionary<string, string>()
                {
                    { nameof(fsyms), fsyms.ToJoinedList() },
                    { nameof(tsyms), tsyms.ToJoinedList() },
                    { nameof(tryConversion), tryConversion?.ToString() },
                    { nameof(e), e }
                });
        }

        public static Uri PriceMultiFull(
            IEnumerable<string> fsyms,
            IEnumerable<string> tsyms,
            bool? tryConversion,
            string e)
        {
            Check.NotEmpty(fsyms, nameof(fsyms));
            Check.NotEmpty(tsyms, nameof(tsyms));

            return new Uri(MinApiEndpoint, "pricemultifull").ApplyParameters(
                new Dictionary<string, string>()
                {
                    { nameof(fsyms), fsyms.ToJoinedList() },
                    { nameof(tsyms), tsyms.ToJoinedList() },
                    { nameof(tryConversion), tryConversion?.ToString() },
                    { nameof(e), e }
                });
        }

        public static Uri PriceSingle(
            [NotNull] string fsym,
            [NotNull] IEnumerable<string> tsyms,
            bool? tryConversion,
            string e)
        {
            Check.NotNullOrWhiteSpace(fsym, nameof(fsym));
            Check.NotEmpty(tsyms, nameof(tsyms));

            return new Uri(MinApiEndpoint, "price").ApplyParameters(
                new Dictionary<string, string>()
                {
                    { nameof(fsym), fsym },
                    { nameof(tsyms), tsyms.ToJoinedList() },
                    { nameof(tryConversion), tryConversion?.ToString() },
                    { nameof(e), e }
                });
        }

        public static Uri RateLimitsByHour() => new Uri(MinApiEndpoint, string.Format(RateLimitsUrl, "hour"));

        public static Uri RateLimitsByMinute() => new Uri(MinApiEndpoint, string.Format(RateLimitsUrl, "minute"));

        public static Uri RateLimitsBySecond() => new Uri(MinApiEndpoint, string.Format(RateLimitsUrl, "second"));

        public static Uri TopPairs([NotNull] string fsym, int? limit)
        {
            Check.NotNullOrWhiteSpace(fsym, nameof(fsym));
            return new Uri(MinApiEndpoint, "top/pairs").ApplyParameters(
                new Dictionary<string, string>()
                {
                    { nameof(fsym), fsym },
                    { nameof(limit), limit.ToString() },
                });
        }

        public static Uri TopExchanges([NotNull] string fsym, [NotNull] string tsym, int? limit)
        {
            Check.NotNullOrWhiteSpace(tsym, nameof(tsym));
            Check.NotNullOrWhiteSpace(fsym, nameof(fsym));
            return new Uri(MinApiEndpoint, "top/exchanges").ApplyParameters(
                new Dictionary<string, string>()
                {
                    { nameof(fsym), fsym },
                    { nameof(tsym), tsym },
                    { nameof(limit), limit.ToString() },
                });
        }

        public static Uri TopVolumes([NotNull] string tsym, int? limit)
        {
            Check.NotNullOrWhiteSpace(tsym, nameof(tsym));
            return new Uri(MinApiEndpoint, "top/volumes").ApplyParameters(
                new Dictionary<string, string>()
                {
                    { nameof(tsym), tsym },
                    { nameof(limit), limit.ToString() },
                });
        }
    }
}
