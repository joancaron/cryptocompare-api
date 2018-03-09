using System.Threading.Tasks;

namespace CryptoCompare
{
    public interface IMiningClient : IApiClient
    {
        /// <summary>
        /// Returns all the mining contracts.
        /// </summary>
        /// <returns>
        /// The asynchronous result that yields a MiningContractsResponse.
        /// </returns>
        Task<MiningContractsResponse> ContractsAsync();

        /// <summary>
        /// Used to get all the mining equipment available on the website.
        /// </summary>
        /// <returns>
        /// The asynchronous result that yields a MiningEquipmentsResponse.
        /// </returns>
        Task<MiningEquipmentsResponse> EquipmentsAsync();
    }
}
