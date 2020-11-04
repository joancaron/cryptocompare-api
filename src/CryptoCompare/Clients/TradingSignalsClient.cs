using System.Net.Http;
using System.Threading.Tasks;
using CryptoCompare.Models.Responses;
using JetBrains.Annotations;

namespace CryptoCompare.Clients
{
    public class TradingSignalsClient : BaseApiClient, ITradingSignalsClient
    {
        /// <summary>
        /// Initializes a new instance of the CryptoCompare.PriceClient class.
        /// </summary>
        /// <param name="httpClient">The HTTP client. This cannot be null.</param>
        public TradingSignalsClient([NotNull] HttpClient httpClient)
            : base(httpClient)
        {
        }

        public async Task<TradingSignalsResponse> BySymbol([NotNull] string toSymbol)
        {
            Check.NotNullOrWhiteSpace(toSymbol, nameof(toSymbol));
            return await this.GetAsync<TradingSignalsResponse>(ApiUrls.TradingSignals(toSymbol)).ConfigureAwait(false);
        }
    }
}