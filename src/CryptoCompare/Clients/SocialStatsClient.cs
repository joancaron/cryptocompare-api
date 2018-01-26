using System.Net.Http;
using System.Threading.Tasks;

using JetBrains.Annotations;

namespace CryptoCompare
{
    public class SocialStatsClient : BaseApiClient, ISocialStatsClient
    {
        /// <summary>
        /// Initializes a new instance of the CryptoCompare.SocialClient class.
        /// </summary>
        /// <param name="httpClient">The HTTP client. This cannot be null.</param>
        public SocialStatsClient([NotNull] HttpClient httpClient)
            : base(httpClient)
        {
        }

        /// <summary>
        /// Get all the available social stats for a coin.
        /// </summary>
        /// <param name="id">coin id.</param>
        /// <returns>
        /// An asynchronous result that yields an object containing the social stats.
        /// </returns>
        /// <seealso cref="M:CryptoCompare.ISocialClient.StatsAsync(int id)"/>
        public async Task<SocialStatsResponse> StatsAsync([NotNull] int id)
        {
            Check.NotNull(id, nameof(id));
            return await this.GetAsync<SocialStatsResponse>(ApiUrls.SocialStats(id))
                       .ConfigureAwait(false);
        }
    }
}
