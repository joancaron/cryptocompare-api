using System.Threading.Tasks;

using CryptoCompare.Responses;

namespace CryptoCompare.Clients
{
    /// <summary>
    /// Interface of api client for cryptocompare api calls rate limits.
    /// </summary>
    public interface IRateLimitsClient
    {
        /// <summary>
        /// Gets the rate limits left for you on the histo, price and news paths in the current hour..
        /// </summary>
        Task<RateLimit> CurrentHourAsync();

        /// <summary>
        /// Gets the rate limits left for you on the histo, price and news paths in the current minute.
        /// </summary>
        Task<RateLimit> CurrentMinuteAsync();

        /// <summary>
        /// Gets the rate limits left for you on the histo, price and news paths in the current second.
        /// </summary>
        Task<RateLimit> CurrentSecondAsync();
    }
}
