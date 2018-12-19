using System;

namespace CryptoCompare
{
    /// <summary>
    /// Interface for cryptocompare api client.
    /// </summary>
    public interface ICryptoCompareClient : IDisposable
    {
        /// <summary>
        /// Gets the api client for coins related api endpoints.
        /// </summary>
        ICoinsClient Coins { get; }

        /// <summary>
        /// Gets the client for exchanges related api endpoints.
        /// </summary>
        IExchangesClient Exchanges { get; }

        /// <summary>
        /// Gets the api client for market history.
        /// </summary>
        IHistoryClient History { get; }

        /// <summary>
        /// Gets the api client for "mining" endpoints.
        /// </summary>
        IMiningClient Mining { get; }

        /// <summary>
        /// Gets the api client for news endpoints.
        /// </summary>
        INewsClient News { get; }

        /// <summary>
        /// Gets the api client for cryptocurrency prices.
        /// </summary>
        IPricesClient Prices { get; }

        /// <summary>
        /// Gets the api client for api calls rate limits.
        /// </summary>
        IRateLimitClient RateLimits { get; }

        /// <summary>
        /// Gets the api client for "social stats" endpoints.
        /// </summary>
        ISocialStatsClient SocialStats { get; }

        /// <summary>
        /// Gets the api client for subs endpoints.
        /// </summary>
        ISubsClient Subs { get; }

        /// <summary>
        /// Gets the api client for "tops" endpoints.
        /// </summary>
        ITopListClient Tops { get; }
    }
}
