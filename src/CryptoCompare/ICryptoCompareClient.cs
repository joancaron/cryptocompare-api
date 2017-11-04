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
        /// Gets the client for api calls rate limits.
        /// </summary>
        IRateLimitsClient RateLimits { get; }

        /// <summary>
        /// Gets the client for coins related api endpoints.
        /// </summary>
        ICoinsClient Coins { get; }
    }
}