using System.Threading.Tasks;

namespace CryptoCompare
{
    /// <summary>
    /// Interface for exchanges api client.
    /// </summary>
    public interface IExchangesClient : IApiClient
    {
        /// <summary>
        /// all the exchanges that CryptoCompare has integrated with..
        /// </summary>
        Task<ExchangeListResponse> ListAsync();

        /// <summary>
        /// all exchanges general info.
        /// </summary>
        /// <returns></returns>
        Task<ExchangeGeneralListResponse> GeneralListAsync();
    }
}
