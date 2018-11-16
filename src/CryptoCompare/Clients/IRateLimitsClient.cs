using System.Threading.Tasks;

namespace CryptoCompare
{
    /// <summary>
    /// Interface of api client for cryptocompare api calls rate limits.
    /// </summary>
    public interface IRateLimitClient : IApiClient
    {
        /// <summary>
        /// Gets the rate limits left for you on the histo, price and news paths in the current hour..
        /// </summary>
        Task<RateLimitResponse> CurrentHourAsync();
    }
}
