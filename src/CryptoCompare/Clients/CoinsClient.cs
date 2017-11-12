using System.Net.Http;
using System.Threading.Tasks;

using JetBrains.Annotations;

namespace CryptoCompare
{
    /// <summary>
    /// The coins client. Gets general info for all the coins available on the website.
    /// </summary>
    /// <seealso cref="T:CryptoCompare.Clients.ICoinsClient"/>
    public class CoinsClient : BaseApiClient, ICoinsClient
    {
        /// <summary>
        /// Initializes a new instance of the CryptoCompare.Clients.CoinsClient class.
        /// </summary>
        /// <param name="httpClient">The HTTP client. This cannot be null.</param>
        public CoinsClient([NotNull] HttpClient httpClient)
            : base(httpClient)
        {
        }

        /// <summary>
        /// Returns all the coins that CryptoCompare has added to the website.
        /// </summary>
        /// <seealso cref="M:CryptoCompare.Clients.ICoinsClient.AllCoinsAsync()"/>
        public async Task<CoinListResponse> ListAsync()
        {
            return await this.GetAsync<CoinListResponse>(ApiUrls.AllCoins()).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets data for a currency pair. It returns general block explorer information,
        /// aggregated data and individual data for each exchange available.
        /// </summary>
        /// <param name="fromSymbol">The symbol of the currency you want to get that for.</param>
        /// <param name="toSymbol">The symbol of the currency that data will be in.</param>
        /// <seealso cref="M:CryptoCompare.Clients.ICoinsClient.SnapshotAsync(string,string)"/>
        public async Task<CoinSnapshotResponse> SnapshotAsync([NotNull] string fromSymbol, [NotNull] string toSymbol)
        {
            Check.NotNull(toSymbol, nameof(toSymbol));
            Check.NotNull(fromSymbol, nameof(fromSymbol));
            return await this.GetAsync<CoinSnapshotResponse>(ApiUrls.CoinSnapshot(fromSymbol, toSymbol))
                       .ConfigureAwait(false);
        }

        /// <summary>
        /// Get the general, subs (used to connect to the streamer and to figure out what exchanges we have data for and what are the exact coin pairs of the coin) 
        /// and the aggregated prices for all pairs available..
        /// </summary>
        /// <param name="id">The id of the coin you want data for.</param>
        /// <returns>
        /// The asynchronous result that yields a full CoinSnapshot.
        /// </returns>
        public async Task<CoinSnapshotFullResponse> SnapshotFullAsync(int id)
        {
            return await this.GetAsync<CoinSnapshotFullResponse>(ApiUrls.CoinSnapshotFull(id)).ConfigureAwait(false);
        }
    }
}
