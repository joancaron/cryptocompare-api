using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using JetBrains.Annotations;

namespace CryptoCompare
{
    public class PriceClient : BaseApiClient, IPricesClient
    {
        /// <summary>
        /// Initializes a new instance of the CryptoCompare.PriceClient class.
        /// </summary>
        /// <param name="httpClient">The HTTP client. This cannot be null.</param>
        public PriceClient([NotNull] HttpClient httpClient)
            : base(httpClient)
        {
        }

        /// <summary>
        /// Compute the current trading info (price, vol, open, high, low etc) of the requested pair as a volume weighted average based on the exchanges requested.
        /// </summary>
        /// <param name="fromSymbol">from symbol.</param>
        /// <param name="toSymbol">to symbol.</param>
        /// <param name="markets">List of names of the exchanges.</param>
        /// <param name="tryConversion">(Optional) If set to false, it will try to get values without
        /// using any conversion at all (defaultVal:true)</param>
        /// <returns>
        /// An asynchronous result that yields the average.
        /// </returns>
        /// <seealso cref="M:CryptoCompare.IPricesClient.GenerateCustomAverageAsync(string,string,IEnumerable{string},bool?)"/>
        public async Task<PriceAverageResponse> GenerateCustomAverageAsync(
            [NotNull] string fromSymbol,
            [NotNull] string toSymbol,
            [NotNull] IEnumerable<string> markets,
            bool? tryConversion = null)
        {
            Check.NotNullOrWhiteSpace(fromSymbol, nameof(fromSymbol));
            Check.NotNullOrWhiteSpace(toSymbol, nameof(toSymbol));
            Check.NotEmpty(markets, nameof(markets));

            return await this.GetAsync<PriceAverageResponse>(
                       ApiUrls.PriceAverage(fromSymbol, toSymbol, markets, tryConversion)).ConfigureAwait(false);
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
        public async Task<PriceMultiResponse> MultipleSymbolsPriceAsync(
            [NotNull] IEnumerable<string> fromSymbols,
            [NotNull] IEnumerable<string> toSymbols,
            bool? tryConversion = null,
            string exchangeName = null)
        {
            Check.NotEmpty(toSymbols, nameof(toSymbols));
            Check.NotEmpty(fromSymbols, nameof(fromSymbols));

            return await this.GetAsync<PriceMultiResponse>(
                       ApiUrls.PriceMulti(fromSymbols, toSymbols, tryConversion, exchangeName)).ConfigureAwait(false);
        }

        /// <summary>
        /// Get all the current trading info (price, vol, open, high, low etc) of any list of cryptocurrencies in any other currency that you need.
        /// If the crypto does not trade directly into the toSymbol requested, BTC will be used for conversion.
        /// This API also returns Display values for all the fields.
        /// If the oposite pair trades we invert it (eg.: BTC-XMR).
        /// </summary>
        /// <param name="fromSymbols">from symbols.</param>
        /// <param name="toSymbols">to symbols.</param>
        /// <param name="tryConversion">(Optional) If set to false, it will try to get values without
        /// using any conversion at all (defaultVal:true)</param>
        /// <param name="exchangeName">(Optional) Exchange name default =&gt; CCCAGG.</param>
        /// <returns>
        /// An asynchronous result that yields the multi full.
        /// </returns>
        /// <seealso cref="M:CryptoCompare.IPricesClient.MultipleSymbolFullDataAsync(IEnumerable{string},IEnumerable{string},bool?,string)"/>
        public async Task<PriceMultiFullResponse> MultipleSymbolFullDataAsync(
            IEnumerable<string> fromSymbols,
            IEnumerable<string> toSymbols,
            bool? tryConversion = null,
            string exchangeName = null)
        {
            Check.NotEmpty(toSymbols, nameof(toSymbols));
            Check.NotEmpty(fromSymbols, nameof(fromSymbols));

            return await this.GetAsync<PriceMultiFullResponse>(
                           ApiUrls.PriceMultiFull(fromSymbols, toSymbols, tryConversion, exchangeName))
                       .ConfigureAwait(false);
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
        public async Task<PriceSingleResponse> SingleSymbolPriceAsync(
            [NotNull] string fromSymbol,
            [NotNull] IEnumerable<string> toSymbols,
            bool? tryConversion = null,
            string exchangeName = null)
        {
            Check.NotNull(fromSymbol, nameof(fromSymbol));
            Check.NotEmpty(toSymbols, nameof(toSymbols));

            return await this.GetAsync<PriceSingleResponse>(
                       ApiUrls.PriceSingle(fromSymbol, toSymbols, tryConversion, exchangeName)).ConfigureAwait(false);
        }
    }
}
