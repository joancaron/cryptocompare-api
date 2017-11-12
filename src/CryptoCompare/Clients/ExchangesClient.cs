using System.Net.Http;
using System.Threading.Tasks;

using JetBrains.Annotations;

namespace CryptoCompare
{
    /// <summary>
    /// The exchanges api client.
    /// </summary>
    /// <seealso cref="T:CryptoCompare.Clients.BaseApiClient"/>
    /// <seealso cref="T:CryptoCompare.Clients.IExchangesClient"/>
    public class ExchangesClient : BaseApiClient, IExchangesClient
    {
        /// <summary>
        /// Initializes a new instance of the CryptoCompare.Clients.ExchangesClient class.
        /// </summary>
        /// <param name="httpClient">The HTTP client. This cannot be null.</param>
        public ExchangesClient([NotNull] HttpClient httpClient)
            : base(httpClient)
        {
        }

        /// <summary>
        /// all the exchanges that CryptoCompare has integrated with.
        /// </summary>
        /// <seealso cref="M:CryptoCompare.Clients.ICoinsClient.AllExchangesAsync()"/>
        public async Task<ExchangeListResponse> ListAsync()
        {
            return await this.GetAsync<ExchangeListResponse>(ApiUrls.AllExchanges()).ConfigureAwait(false);
        }
    }
}
