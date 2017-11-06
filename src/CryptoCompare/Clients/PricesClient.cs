using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using JetBrains.Annotations;

namespace CryptoCompare
{
    public class PricesClient : BaseApiClient, IPricesClient
    {
        public PricesClient([NotNull] HttpClient httpClient)
            : base(httpClient)
        {
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
        public async Task<IDictionary<string, IDictionary<string, decimal>>> Historical(
            [NotNull] string fromSymbol,
            [NotNull] IEnumerable<string> toSymbols,
            DateTimeOffset requestedDate,
            CalculationType? calculationType = null,
            bool? tryConversion = null,
            string exchangeName = null)
        {
            Check.NotNullOrWhiteSpace(fromSymbol, nameof(fromSymbol));
            Check.NotEmpty(toSymbols, nameof(toSymbols));

            return await this.GetAsync<IDictionary<string, IDictionary<string, decimal>>>(
                       ApiUrls.PriceHistorical(
                           fromSymbol,
                           toSymbols,
                           requestedDate,
                           calculationType,
                           tryConversion,
                           exchangeName));
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

        public async Task<PriceMultiFull> MultiFull(
            IEnumerable<string> fromSymbols,
            IEnumerable<string> toSymbols,
            bool? tryConversion = null,
            string exchangeName = null)
        {
            Check.NotEmpty(toSymbols, nameof(toSymbols));
            Check.NotEmpty(fromSymbols, nameof(fromSymbols));

            return await this.GetAsync<PriceMultiFull>(
                       ApiUrls.PriceMultiFull(fromSymbols, toSymbols, tryConversion, exchangeName));
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
