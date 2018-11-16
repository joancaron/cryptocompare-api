using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using JetBrains.Annotations;

namespace CryptoCompare
{
    public class HistoryClient : BaseApiClient, IHistoryClient
    {
        public HistoryClient([NotNull] HttpClient httpClient)
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
        /// <param name="markets">(Optional) Exchange name default =&gt; CCCAGG.</param>
        /// <param name="requestedDate">The requested date.</param>
        /// <param name="calculationType">(Optional) Type of the calculation.</param>
        /// <param name="tryConversion">(Optional) If set to false, it will try to get values without
        /// using any conversion at all (defaultVal:true)</param>
        /// <seealso cref="M:CryptoCompare.Clients.IPricesClient.Historical(string,IEnumerable{string},DateTimeOffset,CalculationType?,bool?,string)"/>
        public async Task<PriceHistoricalReponse> HistoricalAsync(
            [NotNull] string fromSymbol,
            [NotNull] IEnumerable<string> toSymbols,
            DateTimeOffset requestedDate,
            IEnumerable<string> markets = null,
            CalculationType? calculationType = null,
            bool? tryConversion = null)
        {
            Check.NotNullOrWhiteSpace(fromSymbol, nameof(fromSymbol));
            Check.NotEmpty(toSymbols, nameof(toSymbols));

            return await this.GetAsync<PriceHistoricalReponse>(
                       ApiUrls.PriceHistorical(
                           fromSymbol,
                           toSymbols,
                           markets,
                           requestedDate,
                           calculationType,
                           tryConversion)).ConfigureAwait(false);
        }
  
        /// <summary>
        /// Get open, high, low, close, volumefrom and volumeto from the daily historical data.
        /// The values are based on 00:00 GMT time.It uses BTC conversion if data is not available because the coin is not trading in the specified currency.
        /// </summary>
        /// <param name="fromSymbol">from symbol. This cannot be null.</param>
        /// <param name="toSymbol">to symbol. This cannot be null.</param>
        /// <param name="limit">The limit number of returned results.</param>
        /// <param name="exchangeName">List of exchanges names.</param>
        /// <param name="toDate">to date.</param>
        /// <param name="allData">(Optional) retrieve all data.</param>
        /// <param name="aggregate">(Optional) aggregates result.</param>
        /// <param name="tryConversion">(Optional) tries conversion.</param>
        public async Task<HistoryResponse> DayAsync(
            [NotNull] string fromSymbol,
            [NotNull] string toSymbol,
            int? limit = null,
            string exchangeName = null,
            DateTimeOffset? toDate = null,
            bool? allData = null,
            int? aggregate = null,
            bool? tryConversion = null)
        {
            return await this.History(
                       "day",
                       fromSymbol,
                       toSymbol,
                       limit,
                       exchangeName,
                       toDate,
                       allData,
                       aggregate,
                       tryConversion).ConfigureAwait(false);
        }

        /// <summary>
        /// Get open, high, low, close, volumefrom and volumeto from the hourly historical data.
        /// It uses BTC conversion if data is not available because the coin is not trading in the specified currency.
        /// </summary>
        /// <param name="fromSymbol">from symbol. This cannot be null.</param>
        /// <param name="toSymbol">to symbol. This cannot be null.</param>
        /// <param name="limit">The limit number of returned results.</param>
        /// <param name="exchangeName">List of exchanges names.</param>
        /// <param name="toDate">to date.</param>
        /// <param name="allData">(Optional) retrieve all data.</param>
        /// <param name="aggregate">(Optional) aggregates result.</param>
        /// <param name="tryConversion">(Optional) tries conversion.</param>
        public async Task<HistoryResponse> HourAsync(
            [NotNull] string fromSymbol,
            [NotNull] string toSymbol,
            int? limit = null,
            string exchangeName = null,
            DateTimeOffset? toDate = null,
            bool? allData = null,
            int? aggregate = null,
            bool? tryConversion = null)
        {
            return await this.History(
                       "hour",
                       fromSymbol,
                       toSymbol,
                       limit,
                       exchangeName,
                       toDate,
                       allData,
                       aggregate,
                       tryConversion).ConfigureAwait(false);
        }

        /// <summary>
        /// Get open, high, low, close, volumefrom and volumeto from the each minute historical data. 
        /// This data is only stored for 7 days, if you need more,use the hourly or daily path. 
        /// It uses BTC conversion if data is not available because the coin is not trading in the specified currency.
        /// </summary>
        /// <param name="fromSymbol">from symbol. This cannot be null.</param>
        /// <param name="toSymbol">to symbol. This cannot be null.</param>
        /// <param name="limit">The limit number of returned results.</param>
        /// <param name="exchangeName">List of exchanges names.</param>
        /// <param name="toDate">to date.</param>
        /// <param name="allData">(Optional) retrieve all data.</param>
        /// <param name="aggregate">(Optional) aggregates result.</param>
        /// <param name="tryConversion">(Optional) tries conversion.</param>
        public async Task<HistoryResponse> MinuteAsync(
            [NotNull] string fromSymbol,
            [NotNull] string toSymbol,
            int? limit = null,
            string exchangeName = null,
            DateTimeOffset? toDate = null,
            bool? allData = null,
            int? aggregate = null,
            bool? tryConversion = null)
        {
            return await this.History(
                       "minute",
                       fromSymbol,
                       toSymbol,
                       limit,
                       exchangeName,
                       toDate,
                       allData,
                       aggregate,
                       tryConversion).ConfigureAwait(false);
        }

        private async Task<HistoryResponse> History(
            [NotNull] string method,
            [NotNull] string fromSymbol,
            [NotNull] string toSymbol,
            int? limit = null,
            string exchangeName = null,
            DateTimeOffset? toDate = null,
            bool? allData = null,
            int? aggregate = null,
            bool? tryConversion = null)
        {
            Check.NotNullOrWhiteSpace(method, nameof(method));
            Check.NotNullOrWhiteSpace(toSymbol, nameof(toSymbol));
            Check.NotNullOrWhiteSpace(fromSymbol, nameof(fromSymbol));

            return await this.GetAsync<HistoryResponse>(
                       ApiUrls.History(
                           method,
                           fromSymbol,
                           toSymbol,
                           limit,
                           exchangeName,
                           toDate,
                           allData,
                           aggregate,
                           tryConversion)).ConfigureAwait(false);
        }
    }
}
