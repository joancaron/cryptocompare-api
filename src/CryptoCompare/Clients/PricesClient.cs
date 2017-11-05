using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using CryptoCompare.Core;
using CryptoCompare.Helpers;

using JetBrains.Annotations;

namespace CryptoCompare.Clients
{
    public class PricesClient : BaseApiClient, IPricesClient
    {
        public PricesClient([NotNull] HttpClient httpClient)
            : base(httpClient)
        {
        }

        /// <summary>
        /// Same as single API path but with multiple from symbols.
        /// </summary>
        /// <param name="fromSymbols">from symbols.</param>
        /// <param name="toSymbols">to symbols.</param>
        /// <param name="tryConversion">(Optional) If set to false, it will try to get values without
        /// using any conversion at all (defaultVal:true)</param>
        /// <param name="exchangeName">(Optional) Exchange name defult =&gt; CCCAGG.</param>
        /// <seealso cref="M:CryptoCompare.Clients.IPricesClient.Multi(IEnumerable{string},IEnumerable{string},bool?,string)"/>
        public async Task<IDictionary<string, IDictionary<string, decimal>>> Multi(
            [NotNull] IEnumerable<string> fromSymbols,
            [NotNull] IEnumerable<string> toSymbols,
            bool? tryConversion = null,
            string exchangeName = null)
        {
            Check.NotEmpty(toSymbols, nameof(toSymbols));
            Check.NotEmpty(fromSymbols, nameof(fromSymbols));

            return await this.GetAsync<IDictionary<string, IDictionary<string, decimal>>>(
                       ApiUrls.PriceMulti(fromSymbols, toSymbols, tryConversion, exchangeName));
        }

        /// <summary>
        /// Get the current price of any cryptocurrency in any other currency that you need.
        /// If the crypto does not trade directly into the toSymbol requested, BTC will be
        /// used for conversion. If the oposite pair trades we invert it (eg.: BTC-XMR).
        /// </summary>
        /// <param name="fromSymbol">from symbol.</param>
        /// <param name="toSymbols">to symbols.</param>
        /// <param name="tryConversion"></param>
        /// <param name="exchangeName">Exchange name default = CCC</param>
        /// <seealso cref="M:CryptoCompare.Clients.IPricesClient.Single(string,IEnumerable{string})"/>
        public async Task<IDictionary<string, decimal>> Single(
            [NotNull] string fromSymbol,
            [NotNull] IEnumerable<string> toSymbols,
            bool? tryConversion = null,
            string exchangeName = null)
        {
            Check.NotNull(fromSymbol, nameof(fromSymbol));
            Check.NotEmpty(toSymbols, nameof(toSymbols));

            return await this.GetAsync<IDictionary<string, decimal>>(
                       ApiUrls.PriceSingle(fromSymbol, toSymbols, tryConversion, exchangeName));
        }
    }
}
