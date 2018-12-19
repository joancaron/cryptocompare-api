using System.Threading.Tasks;

using JetBrains.Annotations;

namespace CryptoCompare
{
    public interface ITopListClient : IApiClient
    {
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
        Task<TopResponse> ExchangesVolumeDataByPairAsync([NotNull] string fromSymbol, [NotNull] string toSymbol, int? limit = null);

        /// <summary>
        /// Get top pairs by volume for a currency (always uses our aggregated data). 
        /// The number of pairs you get is the minimum of the limit you set (default 5) and the total number of pairs available.
        /// </summary>
        /// <param name="fromSymbol">from symbol.</param>
        /// <param name="limit">(Optional) The limit.</param>
        /// <returns>
        /// An asynchronous result that yields a TopResponse.
        /// </returns>
        Task<TopResponse> TradingPairsAsync([NotNull] string fromSymbol, int? limit = null);

        /// <summary>
        /// Get top coins by volume for the to currency. It returns volume24hto and total supply (where available). 
        /// The number of coins you get is the minimum of the limit you set (default 50) and the total number of coins available.
        /// </summary>
        /// <param name="toSymbol">to symbol.</param>
        /// <param name="limit">(Optional) The limit.</param>
        /// <returns>
        /// An asynchronous result that yields a TopVolumesResponse.
        /// </returns>
        Task<TopVolumesResponse> ByPairVolumeAsync([NotNull] string toSymbol, int? limit = null);

        /// <summary>
        /// Get top exchanges by volume for a currency pair plus the full CCCAGG data. 
        /// The number of exchanges you get is the minimum of the limit you set (default 5) and the total number of exchanges available.
        /// </summary>
        /// <param name="fromSymbol">The cryptocurrency symbol of interest </param>
        /// <param name="toSymbol">The currency symbol to convert into</param>
        /// <param name="limit">(Optional)The number of data points to return.</param>
        Task<TopExchangeFullResponse> ExchangesFullDataByPairAsync([NotNull] string fromSymbol, [NotNull] string toSymbol, int? limit = null);

        /// <summary>
        /// Get top coins by market cap expressed in a given currency.
        /// </summary>
        /// <param name="toSymbol">The symbol of the currency into which the market cap are expressed.</param>
        /// <param name="limit">(Optional)The number currencies to return, default is 10.</param>
        /// <param name="page">(Optional)The pagination for the request.</param>
        /// <param name="sign">(Optional)If set to true, the server will sign the requests, this is useful for usage in smart contracts.</param>
        /// <returns>
        /// The asynchronous result that yields a TopMarketCapResponse.
        /// </returns>
        Task<TopMarketCapResponse> CoinFullDataByMarketCap([NotNull] string toSymbol, int? limit = null, int? page = null, bool? sign = null);

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
        Task<TopVolume24HResponse> CoinFullDataBy24HVolume(string toSymbol, int? limit = null, int? page = null, bool? sign = null);
    }
}
