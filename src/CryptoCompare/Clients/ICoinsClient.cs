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
        /// Returns all the coins that CryptoCompare has added to the website. 
        /// </summary>
        Task<CoinList> ListAsync();
    }
}
