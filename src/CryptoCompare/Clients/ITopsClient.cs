namespace CryptoCompare
{
    using System.Threading.Tasks;

    public interface ITopsClient : IApiClient
    {
        /// <summary>
        /// Get top pairs by volume for a currency (always uses our aggregated data). 
        /// The number of pairs you get is the minimum of the limit you set (default 5) and the total number of pairs available.
        /// </summary>
        /// <param name="fromSymbol">from symbol.</param>
        /// <param name="limit">(Optional) The limit.</param>
        /// <returns>
        /// An asynchronous result that yields a TopResponse.
        /// </returns>
        Task<TopResponse> Pairs(string fromSymbol, int? limit = null);

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
        Task<TopResponse> Exchanges(string fromSymbol,string toSymbol, int? limit = null);

        /// <summary>
        /// Get top coins by volume for the to currency. It returns volume24hto and total supply (where available). 
        /// The number of coins you get is the minimum of the limit you set (default 50) and the total number of coins available.
        /// </summary>
        /// <param name="toSymbol">to symbol.</param>
        /// <param name="limit">(Optional) The limit.</param>
        /// <returns>
        /// An asynchronous result that yields a TopVolumesResponse.
        /// </returns>
        Task<TopVolumesResponse> Volumes(string toSymbol, int? limit = null);
    }
}