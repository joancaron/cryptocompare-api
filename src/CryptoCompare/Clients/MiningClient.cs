using System.Net.Http;
using System.Threading.Tasks;

using JetBrains.Annotations;

namespace CryptoCompare
{
    public class MiningClient : BaseApiClient, IMiningClient
    {
        /// <summary>
        /// Initializes a new instance of the CryptoCompare.MiningClient class.
        /// </summary>
        /// <param name="httpClient">The HTTP client. This cannot be null.</param>
        public MiningClient([NotNull] HttpClient httpClient)
            : base(httpClient)
        {
        }

        /// <summary>
        /// Returns all the mining contracts.
        /// </summary>
        /// <returns>
        /// The asynchronous result that yields a MiningContractsResponse.
        /// </returns>
        public async Task<MiningContractsResponse> ContractsAsync() =>
            await this.GetAsync<MiningContractsResponse>(ApiUrls.MiningContracts());

        /// <summary>
        /// Used to get all the mining equipment available on the website.
        /// </summary>
        /// <returns>
        /// The asynchronous result that yields a MiningEquipmentsResponse.
        /// </returns>
        public async Task<MiningEquipmentsResponse> EquipmentsAsync() =>
            await this.GetAsync<MiningEquipmentsResponse>(ApiUrls.MiningEquipments());
    }
}
