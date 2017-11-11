using System.Threading.Tasks;

namespace CryptoCompare
{
    /// <summary>
    /// Interface of api client for cryptocompare api calls rate limits.
    /// </summary>
    public interface IRateLimitsClient : IApiClient
    {
        /// <summary>
        /// Gets the rate limits left for you on the histo, price and news paths in the current hour..
        /// </summary>
        Task<RateLimitResponse> CurrentHourAsync();

        /// <summary>
        /// Gets the rate limits left for you on the histo, price and news paths in the current minute.
        /// </summary>
        Task<RateLimitResponse> CurrentMinuteAsync();

        /// <summary>
        /// Gets the rate limits left for you on the histo, price and news paths in the current second.
        /// </summary>
        Task<RateLimitResponse> CurrentSecondAsync();
    }
}
