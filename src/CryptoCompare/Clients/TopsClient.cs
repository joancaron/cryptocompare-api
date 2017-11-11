using System.Net.Http;
using JetBrains.Annotations;

namespace CryptoCompare
{
    using System.Threading.Tasks;

    /// <summary>
    /// Client for "tops" endpoints (Exchanges, volumes, pairs).
    /// </summary>
    /// <seealso cref="T:CryptoCompare.BaseApiClient"/>
    /// <seealso cref="T:CryptoCompare.ITopsClient"/>
    public class TopsClient : BaseApiClient, ITopsClient
    {
        /// <summary>
        /// Initializes a new instance of the CryptoCompare.TopsClient class.
        /// </summary>
        /// <param name="httpClient">The HTTP client. This cannot be null.</param>
        public TopsClient([NotNull] HttpClient httpClient) : base(httpClient)
        {
        }

        /// <summary>
        /// Get top pairs by volume for a currency (always uses our aggregated data).
        /// The number of pairs you get is the minimum of the limit you set (default 5) and the total number of pairs available.
        /// </summary>
        /// <param name="fromSymbol">from symbol.</param>
        /// <param name="limit">(Optional) The limit.</param>
        /// <returns>
        /// An asynchronous result that yields a TopResponse.
        /// </returns>
        /// <seealso cref="M:CryptoCompare.ITopsClient.Pairs(string,int?)"/>
        public async Task<TopResponse> Pairs([NotNull] string fromSymbol, int? limit = null)
        {
            Check.NotNullOrWhiteSpace(fromSymbol, nameof(fromSymbol));
            return await this.GetAsync<TopResponse>(ApiUrls.TopPairs(fromSymbol, limit));
        }

        /// <summary>
        /// Get top exchanges by volume for a currency pair.
        /// The number of exchanges you get is the minimum of the limit you set (default 5) and the total number of exchanges available.
        /// </summary>
        /// <param name="fromSymbol">from symbol.</param>
        /// <param name="toSymbol">to symbol.</param>
        /// <param name="limit">(Optional) The limit.</param>
        /// <returns>
        /// An asynchronous result that yields a TopResponse.
        /// </returns>
        /// <seealso cref="M:CryptoCompare.ITopsClient.Exchanges(string,string,int?)"/>
        public async Task<TopResponse> Exchanges([NotNull] string fromSymbol, [NotNull] string toSymbol, int? limit = null)
        {
            Check.NotNullOrWhiteSpace(toSymbol, nameof(toSymbol));
            Check.NotNullOrWhiteSpace(fromSymbol, nameof(fromSymbol));
            return await this.GetAsync<TopResponse>(ApiUrls.TopExchanges(fromSymbol, toSymbol, limit));
        }

        /// <summary>
        /// Get top coins by volume for the to currency. It returns volume24hto and total supply (where available).
        /// The number of coins you get is the minimum of the limit you set (default 50) and the total number of coins available.
        /// </summary>
        /// <param name="toSymbol">to symbol.</param>
        /// <param name="limit">(Optional) The limit.</param>
        /// <returns>
        /// An asynchronous result that yields a TopVolumesResponse.
        /// </returns>
        /// <seealso cref="M:CryptoCompare.ITopsClient.Volumes(string,int?)"/>
        public async Task<TopVolumesResponse> Volumes([NotNull] string toSymbol, int? limit = null)
        {
            Check.NotNullOrWhiteSpace(toSymbol, nameof(toSymbol));
            return await this.GetAsync<TopVolumesResponse>(ApiUrls.TopVolumes(toSymbol, limit));
        }
    }
}