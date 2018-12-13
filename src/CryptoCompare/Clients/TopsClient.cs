using System.Net.Http;
using System.Threading.Tasks;

using CryptoCompare.Models.Responses;

using JetBrains.Annotations;

namespace CryptoCompare
{
    /// <summary>
    /// Client for "tops" endpoints (Exchanges, volumes, pairs).
    /// </summary>
    /// <seealso cref="T:CryptoCompare.BaseApiClient"/>
    /// <seealso cref="T:CryptoCompare.ITopsClient"/>
    public class TopListClient : BaseApiClient, ITopListClient
    {
        /// <summary>
        /// Initializes a new instance of the CryptoCompare.TopsClient class.
        /// </summary>
        /// <param name="httpClient">The HTTP client. This cannot be null.</param>
        public TopListClient([NotNull] HttpClient httpClient)
            : base(httpClient)
        {
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
        public async Task<TopResponse> ExchangesVolumeDataByPairAsync(
            [NotNull] string fromSymbol,
            [NotNull] string toSymbol,
            int? limit = null)
        {
            Check.NotNullOrWhiteSpace(toSymbol, nameof(toSymbol));
            Check.NotNullOrWhiteSpace(fromSymbol, nameof(fromSymbol));
            return await this.GetAsync<TopResponse>(ApiUrls.TopExchangesVolumeDataByPair(fromSymbol, toSymbol, limit))
                       .ConfigureAwait(false);
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
        public async Task<TopResponse> TradingPairsAsync([NotNull] string fromSymbol, int? limit = null)
        {
            Check.NotNullOrWhiteSpace(fromSymbol, nameof(fromSymbol));
            return await this.GetAsync<TopResponse>(ApiUrls.TopOfTradingPairs(fromSymbol, limit)).ConfigureAwait(false);
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
        public async Task<TopVolumesResponse> ByPairVolumeAsync([NotNull] string toSymbol, int? limit = null)
        {
            Check.NotNullOrWhiteSpace(toSymbol, nameof(toSymbol));
            return await this.GetAsync<TopVolumesResponse>(ApiUrls.TopByPairVolume(toSymbol, limit)).ConfigureAwait(false);
        }

        /// <summary>
        /// Get top exchanges by volume for a currency pair plus the full CCCAGG data. The number of
        /// exchanges you get is the minimum of the limit you set (default 5) and the total number of
        /// exchanges available.
        /// </summary>
        /// <param name="fromSymbol">The cryptocurrency symbol of interest.</param>
        /// <param name="toSymbol">The currency symbol to convert into.</param>
        /// <param name="limit">(Optional)The number of data points to return.</param>
        /// <returns>
        /// The asynchronous result that yields a TopResponse.
        /// </returns>
        /// <seealso cref="M:CryptoCompare.ITopListClient.ExchangesFullDataByPairAsync(string,string,int?)"/>
        public async Task<TopExchangeFullResponse> ExchangesFullDataByPairAsync(string fromSymbol, string toSymbol, int? limit = null)
        {
            Check.NotNullOrWhiteSpace(toSymbol, nameof(toSymbol));
            return await this.GetAsync<TopExchangeFullResponse>(ApiUrls.ExchangesFullDataByPair(fromSymbol, toSymbol,limit)).ConfigureAwait(false);
        }

        /// <summary>
        /// Get full data for the top coins ordered by market cap as expressed in a given currency.
        /// </summary>
        /// <param name="toSymbol">The symbol of the currency into which the market cap are expressed.</param>
        /// <param name="limit">(Optional)The number currencies to return, default is 10.</param>
        /// <param name="page">(Optional)The pagination for the request.</param>
        /// <param name="sign">(Optional)If set to true, the server will sign the requests, this is useful for usage in smart contracts.</param>
        /// <returns>
        /// The asynchronous result that yields a TopMarketCapResponse.
        /// </returns>
        /// <seealso cref="M:CryptoCompare.ITopListClient.CoinFullDataByMarketCap(string,int?,int?,bool?)"/>
        public async Task<TopMarketCapResponse> CoinFullDataByMarketCap(string toSymbol, int? limit = null, int? page = null, bool? sign = null)
        {
            Check.NotNullOrWhiteSpace(toSymbol, nameof(toSymbol));
            return await this.GetAsync<TopMarketCapResponse>(ApiUrls.TopByMarketCapFull(toSymbol, limit, page, sign)).ConfigureAwait(false);
        }

        /// <summary>
        /// Get full data for the top coins ordered by their total volume across all markets in the last 24 hours as expressed in a given currency.
        /// </summary>
        /// <param name="toSymbol">The symbol of the currency into which the market cap are expressed.</param>
        /// <param name="limit">(Optional)The number currencies to return, default is 10.</param>
        /// <param name="page">(Optional)The pagination for the request.</param>
        /// <param name="sign">(Optional)If set to true, the server will sign the requests, this is useful for usage in smart contracts.</param>
        /// <returns>
        /// The asynchronous result that yields a TopVolume24HResponse.
        /// </returns>
        /// <seealso cref="M:CryptoCompare.ITopListClient.CoinFullDataBy24HVolume(string,int?,int?,bool?)"/>
        public async Task<TopVolume24HResponse> CoinFullDataBy24HVolume(string toSymbol, int? limit = null, int? page = null, bool? sign = null)
        {
            Check.NotNullOrWhiteSpace(toSymbol, nameof(toSymbol));
            return await this.GetAsync<TopVolume24HResponse>(ApiUrls.TopByVolume24HFull(toSymbol, limit, page, sign)).ConfigureAwait(false);
        }
    }
}
