using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using JetBrains.Annotations;

namespace CryptoCompare
{
    public class PricesClient : BaseApiClient, IPricesClient
    {
        /// <summary>
        /// Initializes a new instance of the CryptoCompare.PricesClient class.
        /// </summary>
        /// <param name="httpClient">The HTTP client. This cannot be null.</param>
        public PricesClient([NotNull] HttpClient httpClient)
            : base(httpClient)
        {
        }

        /// <summary>
        /// Compute the current trading info (price, vol, open, high, low etc) of the requested pair as a volume weighted average based on the exchanges requested.
        /// </summary>
        /// <param name="fromSymbol">from symbol.</param>
        /// <param name="toSymbol">to symbol.</param>
        /// <param name="exchangeNames">List of names of the exchanges.</param>
        /// <param name="tryConversion">(Optional) If set to false, it will try to get values without
        /// using any conversion at all (defaultVal:true)</param>
        /// <returns>
        /// An asynchronous result that yields the average.
        /// </returns>
        /// <seealso cref="M:CryptoCompare.IPricesClient.AverageAsync(string,string,IEnumerable{string},bool?)"/>
        public async Task<PriceAverageResponse> AverageAsync(
            [NotNull] string fromSymbol,
            [NotNull] string toSymbol,
            [NotNull] IEnumerable<string> exchangeNames,
            bool? tryConversion = null)
        {
            Check.NotNullOrWhiteSpace(fromSymbol, nameof(fromSymbol));
            Check.NotNullOrWhiteSpace(toSymbol, nameof(toSymbol));
            Check.NotEmpty(exchangeNames, nameof(exchangeNames));

            return await this.GetAsync<PriceAverageResponse>(
                       ApiUrls.PriceAverage(fromSymbol, toSymbol, exchangeNames, tryConversion)).ConfigureAwait(false);
        }

        /// <summary>
        /// Get the price of any cryptocurrency in any other currency that you need at a given timestamp.
        /// The price comes from the daily info - so it would be the price at the end of the day GMT based on the requested TS.
        /// If the crypto does not trade directly into the toSymbol requested, BTC will be used for conversion.
        /// Tries to get direct trading pair data, if there is none or it is more than 10 days before the ts requested, it uses BTC conversion.
        /// If the oposite pair trades we invert it (eg.: BTC-XMR)The calculation types are: Close - a Close of the day close price,MidHighLow - the average between the 24 H high and low.VolFVolT - the total volume to / the total volume from.
        /// </summary>
        /// <param name="fromSymbol">from symbol.</param>
        /// <param name="toSymbols">to symbols.</param>
        /// <param name="requestedDate">The requested date.</param>
        /// <param name="calculationType">(Optional) Type of the calculation.</param>
        /// <param name="tryConversion">(Optional) If set to false, it will try to get values without
        /// using any conversion at all (defaultVal:true)</param>
        /// <param name="exchangeName">(Optional) Exchange name default =&gt; CCCAGG.</param>
        /// <seealso cref="M:CryptoCompare.Clients.IPricesClient.Historical(string,IEnumerable{string},DateTimeOffset,CalculationType?,bool?,string)"/>
        public async Task<PriceHistoricalReponse> HistoricalAsync(
            [NotNull] string fromSymbol,
            [NotNull] IEnumerable<string> toSymbols,
            DateTimeOffset requestedDate,
            CalculationType? calculationType = null,
            bool? tryConversion = null,
            string exchangeName = null)
        {
            Check.NotNullOrWhiteSpace(fromSymbol, nameof(fromSymbol));
            Check.NotEmpty(toSymbols, nameof(toSymbols));

            return await this.GetAsync<PriceHistoricalReponse>(
                       ApiUrls.PriceHistorical(
                           fromSymbol,
                           toSymbols,
                           requestedDate,
                           calculationType,
                           tryConversion,
                           exchangeName)).ConfigureAwait(false);
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
        public async Task<PriceMultiResponse> MultiAsync(
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
        /// <seealso cref="M:CryptoCompare.IPricesClient.MultiFullAsync(IEnumerable{string},IEnumerable{string},bool?,string)"/>
        public async Task<PriceMultiFullResponse> MultiFullAsync(
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
        public async Task<PriceSingleResponse> SingleAsync(
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
