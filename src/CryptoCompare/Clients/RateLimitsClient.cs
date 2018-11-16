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
    public class RateLimitClient : BaseApiClient, IRateLimitClient
    {
        /// <summary>
        /// Initializes a new instance of the CryptoCompare.Clients.RateLimitsClient class.
        /// </summary>
        /// <param name="httpClient">The HTTP client. This cannot be null.</param>
        public RateLimitClient([NotNull] HttpClient httpClient)
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
            return await this.GetAsync<RateLimitResponse>(ApiUrls.RateLimitsByHour()).ConfigureAwait(false);
        }
    }
}
