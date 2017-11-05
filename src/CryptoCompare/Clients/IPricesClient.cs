using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using CryptoCompare.Core;
using CryptoCompare.Helpers;

using JetBrains.Annotations;

namespace CryptoCompare.Clients
{
    public interface IPricesClient : IApiClient
    {
        /// <summary>
        /// Get the current price of any cryptocurrency in any other currency that you need.
        /// If the crypto does not trade directly into the toSymbol requested, BTC will be used for conversion.
        /// If the oposite pair trades we invert it (eg.: BTC-XMR).
        /// </summary>
        /// <param name="fromSymbol">from symbol.</param>
        /// <param name="toSymbols">to symbols.</param>
        Task<IDictionary<string, decimal>> Single(string fromSymbol, IEnumerable<string> toSymbols);
    }

    public class PricesClient : BaseApiClient, IPricesClient
    {
        public PricesClient([NotNull] HttpClient httpClient)
            : base(httpClient)
        {
        }

        /// <summary>
        /// Get the current price of any cryptocurrency in any other currency that you need.
        /// If the crypto does not trade directly into the toSymbol requested, BTC will be
        /// used for conversion. If the oposite pair trades we invert it (eg.: BTC-XMR).
        /// </summary>
        /// <param name="fromSymbol">from symbol.</param>
        /// <param name="toSymbols">to symbols.</param>
        /// <seealso cref="M:CryptoCompare.Clients.IPricesClient.Single(string,IEnumerable{string})"/>
        public async Task<IDictionary<string, decimal>> Single([NotNull] string fromSymbol, [NotNull] IEnumerable<string> toSymbols)
        {
            Check.NotNull(fromSymbol, nameof(fromSymbol));
            Check.NotEmpty(toSymbols, nameof(toSymbols));

            return await this.SendRequestAsync<IDictionary<string, decimal>>(
                       HttpMethod.Get,
                       ApiUrls.PriceSingle(fromSymbol, toSymbols));
        }
    }
}
