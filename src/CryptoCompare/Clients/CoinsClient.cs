using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using CryptoCompare.Core;
using CryptoCompare.Responses;

using JetBrains.Annotations;

using Newtonsoft.Json.Serialization;

namespace CryptoCompare.Clients
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
        public async Task<CoinList> AllCoinsAsync()
        {
            return await this.SendRequestAsync<CoinList>(
                       HttpMethod.Get,
                       ApiUrls.AllCoins);
        }

        /// <summary>
        /// all the exchanges that CryptoCompare has integrated with.
        /// </summary>
        /// <seealso cref="M:CryptoCompare.Clients.ICoinsClient.AllExchangesAsync()"/>
        public async Task<IDictionary<string, IDictionary<string, IEnumerable<string>>>> AllExchangesAsync()
        {
            return await this.SendRequestAsync<IDictionary<string, IDictionary<string, IEnumerable<string>>>>(
                       HttpMethod.Get,
                       ApiUrls.AllExchanges);
        }
    }
}
