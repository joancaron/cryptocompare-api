using System.Threading.Tasks;

using CryptoCompare.Responses;

namespace CryptoCompare.Clients
{
    /// <summary>
    /// Coins api client. Gets general info for all the coins available on the website.
    /// </summary>
    public interface ICoinsClient
    {
        /// <summary>
        /// Returns all the coins that CryptoCompare has added to the website. This is not the full list of coins we have in the system, it is just the list of coins we have done some research on.
        /// </summary>
        Task<CoinList> AllCoinsAsync();
    }
}
