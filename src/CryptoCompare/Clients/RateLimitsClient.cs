using System.Net.Http;
using System.Threading.Tasks;

using JetBrains.Annotations;

namespace CryptoCompare
{
    /// <summary>
    /// Api client for cryptocompare api calls rate limits.
    /// </summary>
    /// <seealso cref="T:CryptoCompare.Clients.BaseApiClient"/>
    /// <seealso cref="T:CryptoCompare.Clients.IRateLimitsClient"/>
    public class RateLimitsClient : BaseApiClient, IRateLimitsClient
    {
        /// <summary>
        /// Initializes a new instance of the CryptoCompare.Clients.RateLimitsClient class.
        /// </summary>
        /// <param name="httpClient">The HTTP client. This cannot be null.</param>
        public RateLimitsClient([NotNull] HttpClient httpClient)
            : base(httpClient)
        {
        }

        /// <summary>
        /// Gets the rate limits left for you on the histo, price and news paths in the
        /// current hour.
        /// </summary>
        /// <seealso cref="M:CryptoCompare.Clients.IRateLimitsClient.Hour()"/>
        public async Task<RateLimitResponse> CurrentHourAsync()
        {
            return await this.GetAsync<RateLimitResponse>(ApiUrls.RateLimitsByHour());
        }

        /// <summary>
        /// Gets the rate limits left for you on the histo, price and news paths in the
        /// current minute.
        /// </summary>
        /// <seealso cref="M:CryptoCompare.Clients.IRateLimitsClient.Minute()"/>
        public async Task<RateLimitResponse> CurrentMinuteAsync()
        {
            return await this.GetAsync<RateLimitResponse>(ApiUrls.RateLimitsByMinute());
        }

        /// <summary>
        /// Gets the rate limits left for you on the histo, price and news paths in the
        /// current second.
        /// </summary>
        /// <seealso cref="M:CryptoCompare.Clients.IRateLimitsClient.Second()"/>
        public async Task<RateLimitResponse> CurrentSecondAsync()
        {
            return await this.GetAsync<RateLimitResponse>(ApiUrls.RateLimitsBySecond());
        }
    }
}
