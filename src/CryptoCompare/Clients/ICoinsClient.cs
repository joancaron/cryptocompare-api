using System.Threading.Tasks;

using CryptoCompare.Responses;

namespace CryptoCompare.Clients
{
    /// <summary>
    /// Coins api client. Gets general info for all the coins available on the website.
    /// </summary>
    public interface ICoinsClient : IApiClient
    {
        /// <summary>
        /// Returns all the coins that CryptoCompare has added to the website. 
        /// </summary>
        Task<CoinList> ListAsync();

        /// <summary>
        /// Gets data for a currency pair. 
        /// It returns general block explorer information, aggregated data and individual data for each exchange available.
        /// </summary>
        /// <param name="fromSymbol">The symbol of the currency you want to get that for.</param>
        /// <param name="toSymbol">The symbol of the currency that data will be in.</param>
        Task<CoinSnapshot> SnapshotAsync(string fromSymbol, string toSymbol);

        /// <summary>
        /// Get the general, subs (used to connect to the streamer and to figure out what exchanges we have data for and what are the exact coin pairs of the coin) 
        /// and the aggregated prices for all pairs available..
        /// </summary>
        /// <param name="id">The id of the coin you want data for.</param>
        /// <returns>
        /// The asynchronous result that yields a full CoinSnapshot.
        /// </returns>
        Task<CoinSnapshotFull> SnapshotFullAsync(int id);
    }
}
