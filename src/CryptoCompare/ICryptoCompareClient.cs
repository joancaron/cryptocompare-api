using System;

using CryptoCompare.Clients;

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
        /// Gets the api client for api calls rate limits.
        /// </summary>
        IRateLimitsClient RateLimits { get; }
    }
}
