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
        /// Gets the api client for cryptocurrency prices.
        /// </summary>
        IPricesClient Prices { get; }

        /// <summary>
        /// Gets the api client for api calls rate limits.
        /// </summary>
        IRateLimitsClient RateLimits { get; }

        /// <summary>
        /// Gets the api client for market history.
        /// </summary>
        IHistoryClient History { get; }

        /// <summary>
        /// Gets the api client for "tops" endpoints.
        /// </summary>
        ITopsClient Tops { get; }

        /// <summary>
        /// Gets the api client for subs endpoints.
        /// </summary>
        ISubsClient Subs { get; }
    }
}
